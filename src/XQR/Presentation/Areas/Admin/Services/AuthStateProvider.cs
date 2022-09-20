namespace Azox.XQR.Presentation.Areas.Admin.Services
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Models.Management;
    using Azox.XQR.Presentation.Areas.Admin.Configs;
    using Azox.XQR.Presentation.Areas.Admin.Models;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Threading.Tasks;

    internal class AuthStateProvider :
        AuthenticationStateProvider,
        IAuthStateProvider
    {
        #region Fields

        private const string AUTH_TOKEN_NAME = "xqr-auth-token";
        private const string AUTHENTICATION_TYPE = "xqr-auth";

        private readonly ILogger<AuthStateProvider> _logger;
        private readonly IUserService _userService;
        private readonly ProtectedSessionStorage _protectedSessionStorage;
        private readonly SymmetricSecurityKey _symmetricSecurityKey;

        #endregion Fields

        #region Ctor

        public AuthStateProvider(
            ILogger<AuthStateProvider> logger,
            IUserService userService,
            ProtectedSessionStorage protectedSessionStorage,
            JwtConfig jwtConfig)
        {
            _logger = logger;
            _userService = userService;
            _protectedSessionStorage = protectedSessionStorage;
            _symmetricSecurityKey = new(jwtConfig.SecretKeyBytes);
        }

        #endregion Ctor

        #region Utils

        private AuthenticationState GetAuthenticationState(List<Claim>? claims)
        {
            ClaimsIdentity identity = new();
            if (claims != null)
            {
                identity = new(claims, AUTHENTICATION_TYPE);
            }
            ClaimsPrincipal principal = new(identity);
            return new(principal);
        }


        private string GenerateJwtToken(string username)
        {
            ClaimsIdentity identity = new(new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
            }, AUTHENTICATION_TYPE);

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

        private bool VerifyToken(string token, out string? username)
        {
            username = null;
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
                ProtectedBrowserStorageResult<string> storageResult = await _protectedSessionStorage
                    .GetAsync<string>(AUTH_TOKEN_NAME);

                if (storageResult.Success && VerifyToken(storageResult.Value, out string? username))
                {
                    string token = GenerateJwtToken(username);

                    await _protectedSessionStorage.SetAsync(AUTH_TOKEN_NAME, token);

                    return GetAuthenticationState(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                });
                }

                return GetAuthenticationState(null);
            }
            catch
            {
                return GetAuthenticationState(null);
            }
        }

        public async Task<ValidateCredentialsResult> LoginAsync(LoginModel loginModel)
        {
            ValidateCredentialsResult result = await _userService
                .ValidateCredentials(loginModel.Username, loginModel.Password);

            if (result.Success)
            {
                string token = GenerateJwtToken(loginModel.Username);

                await _protectedSessionStorage.SetAsync(AUTH_TOKEN_NAME, token);
            }

            return result;
        }

        #endregion Methods
    }
}
