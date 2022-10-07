namespace Azox.XQR.Presentation.Web.Core.Services
{
    using Azox.Core.Extensions;
    using Azox.XQR.Business;
    using Azox.XQR.Presentation.Web.Core.Configs;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.IdentityModel.Tokens;

    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Threading.Tasks;

    internal class LoginService :
        AuthenticationStateProvider,
        ILoginService
    {
        #region Fields

        private const string AUTH_TOKEN_NAME = "xqr-auth-token";
        private const string AUTHENTICATION_TYPE = "xqr-auth";

        private readonly ILogger<LoginService> _logger;
        private readonly IUserService _userService;
        private readonly ILocalStorageService _localStorageService;
        private readonly NavigationManager _navigationManager;
        private readonly SymmetricSecurityKey _symmetricSecurityKey;

        #endregion Fields

        #region Ctor

        public LoginService(
            ILogger<LoginService> logger,
            IServiceScopeFactory serviceScopeFactory,
            ILocalStorageService localStorageService,
            NavigationManager navigationManager,
            JwtConfig jwtConfig)
        {
            IServiceProvider serviceProvider = serviceScopeFactory.CreateAsyncScope().ServiceProvider;

            _logger = logger;
            _userService = serviceProvider.GetRequiredService<IUserService>();
            _localStorageService = localStorageService;
            _navigationManager = navigationManager;

            _symmetricSecurityKey = new(jwtConfig.SecretKeyBytes);
        }

        #endregion Ctor

        #region Utils

        private IEnumerable<Claim> GetClaims(string username, UserGroupType userGroupType)
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, userGroupType.ToString())
            };
        }

        private AuthenticationState GetAuthenticationState(IEnumerable<Claim>? claims)
        {
            ClaimsIdentity identity = new();

            if (claims != null && claims.Any())
            {
                identity = new(AUTHENTICATION_TYPE);
                identity.AddClaims(claims);
            }

            ClaimsPrincipal principal = new(identity);

            return new AuthenticationState(principal);
        }

        private string GenerateJwtToken(string username, UserGroupType userGroupType)
        {
            ClaimsIdentity identity = new(AUTHENTICATION_TYPE);
            identity.AddClaims(GetClaims(username, userGroupType));

            SigningCredentials credentials = new(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            SecurityTokenDescriptor descriptor = new()
            {
                Subject = identity,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials
            };

            JwtSecurityTokenHandler tokenHandler = new();
            SecurityToken token = tokenHandler.CreateToken(descriptor);

            return tokenHandler.WriteToken(token);
        }

        private bool VerifyToken(string token, out string username, out UserGroupType userGroupType)
        {
            username = String.Empty;
            userGroupType = UserGroupType.ServiceUser;
            try
            {
                TokenValidationParameters validationParameters = new()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = _symmetricSecurityKey
                };

                JwtSecurityTokenHandler tokenHandler = new();
                ClaimsPrincipal principal = tokenHandler
                    .ValidateToken(token, validationParameters, out SecurityToken validationToken);

                if (validationToken is JwtSecurityToken securityToken
                    && securityToken != null
                    && securityToken.ValidTo > DateTime.UtcNow)
                {
                    username = principal?.Identity?.Name;
                    if (Enum.TryParse<UserGroupType>(principal?.FindFirstValue(ClaimTypes.Role), out UserGroupType _userGroupType))
                    {
                        userGroupType = _userGroupType;
                    }
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }

        #endregion Utils

        #region Methods

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                string storageResult = await _localStorageService
                    .GetItemAsStringAsync(AUTH_TOKEN_NAME);

                if (!storageResult.IsNullOrEmpty() && VerifyToken(storageResult, out string username, out UserGroupType userGroupType))
                {
                    string token = GenerateJwtToken(username, userGroupType);

                    await _localStorageService.SetItemAsStringAsync(AUTH_TOKEN_NAME, token);

                    return GetAuthenticationState(GetClaims(username, userGroupType));
                }

                return GetAuthenticationState(null);
            }
            catch
            {
                return GetAuthenticationState(null);
            }
        }

        public async Task<ValidateCredentialsResult> LoginAsync(string username, string password)
        {
            ValidateCredentialsResult result = await _userService
                .ValidateCredentials(username, password);

            if (result == ValidateCredentialsResult.Succeeded)
            {
                User user = await _userService.GetByUsernameAsync(username);
                string token = GenerateJwtToken(username, user.UserGroup.UserGroupType);

                await _localStorageService.SetItemAsStringAsync(AUTH_TOKEN_NAME, token);

                Task<AuthenticationState> authState = Task.FromResult(GetAuthenticationState(GetClaims(username, user.UserGroup.UserGroupType)));

                NotifyAuthenticationStateChanged(authState);
            }

            return result;
        }

        public async Task LogoutAsync()
        {
            await _localStorageService.RemoveItemAsync(AUTH_TOKEN_NAME);
            _navigationManager.NavigateTo("/admin", true);
        }

        #endregion Methods
    }
}
