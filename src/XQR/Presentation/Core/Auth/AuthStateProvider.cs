namespace Azox.XQR.Presentation.Core.Auth
{
    using Azox.Core.Extensions;
    using Azox.XQR.Business;
    using Azox.XQR.Presentation.Core.Configs;
    using Azox.XQR.Presentation.Core.Extensions;

    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
    using Microsoft.IdentityModel.Tokens;

    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Threading.Tasks;

    internal class AuthStateProvider :
        AuthenticationStateProvider,
        IAuthService
    {
        #region Fields

        private const string AUTH_TOKEN_NAME = "xqr-auth-token";
        private const string AUTHENTICATION_TYPE = "xqr-auth";

        private readonly SymmetricSecurityKey _symmetricSecurityKey;
        private readonly ProtectedLocalStorage _localStorage;
        private readonly IUserService _userService;
        private readonly IMerchantServeUserService _merchantServeUserService;

        #endregion Fields

        #region Ctor

        public AuthStateProvider(
            JwtConfig jwtConfig,
            ProtectedLocalStorage localStorage,
            IUserService userService,
            IMerchantServeUserService merchantServeUserService)
        {
            _symmetricSecurityKey = new(jwtConfig.SecretKeyBytes);
            _localStorage = localStorage;
            _userService = userService;
            _merchantServeUserService = merchantServeUserService;
        }

        #endregion Ctor

        #region Utils

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

        private string GetToken(ClaimsPrincipal principal)
        {
            ClaimsIdentity identity = new(AUTHENTICATION_TYPE);
            identity.AddClaims(principal.Claims);

            SigningCredentials credentials = new(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials
            };

            JwtSecurityTokenHandler tokenHandler = new();
            SecurityToken securityToken = tokenHandler.CreateToken(securityTokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }

        private bool VerifyToken(string token, out ClaimsPrincipal? principal)
        {
            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = _symmetricSecurityKey
            };

            JwtSecurityTokenHandler tokenHandler = new();
            if (!tokenHandler.CanValidateToken)
            {
                principal = null;
                return false;
            }

            try
            {
                principal = tokenHandler
                    .ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);

                if (validatedToken is JwtSecurityToken securityToken)
                {
                    if (securityToken == null)
                    {
                        return false;
                    }

                    if (securityToken.ValidTo < DateTime.UtcNow)
                    {
                        return false;
                    }

                    return true;
                }
            }
            catch
            {
                principal = null;
                return false;
            }

            return false;
        }

        #endregion Utils

        #region Methods

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            ProtectedBrowserStorageResult<string> result = await _localStorage
                .GetAsync<string>(AUTH_TOKEN_NAME);

            if (!result.Success || result.Value.IsNullOrEmpty())
            {
                return GetAuthenticationState(null);
            }

            if (VerifyToken(result.Value, out ClaimsPrincipal principal))
            {
                string token = GetToken(principal);
                await _localStorage.SetAsync(AUTH_TOKEN_NAME, token);
                return GetAuthenticationState(principal.Claims);
            }

            return GetAuthenticationState(null);
        }

        public async Task<ValidateCredentialsResult> SignIn(string username, string password)
        {
            ValidateCredentialsResult result = _userService
                .ValidateCredentials(username, password);

            if (result == ValidateCredentialsResult.Succeeded)
            {
                User user = _userService.GetByUsername(username);
                IEnumerable<int> userServices = _merchantServeUserService
                    .Filter(x => x.User.Id == user.Id)
                    .Select(x => x.Service.Id);

                ClaimsIdentity identity = new(AUTHENTICATION_TYPE);

                identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
                identity.AddClaim(new Claim(ClaimTypes.Role, user.UserGroup.UserGroupType.ToString()));
                identity.AddClaim(new Claim(ClaimsPrincipalExtensions.UserServicesClaimType, string.Join(",", userServices)));

                ClaimsPrincipal principal = new(identity);

                string token = GetToken(principal);

                await _localStorage.SetAsync(AUTH_TOKEN_NAME, token);

                NotifyAuthenticationStateChanged(Task.FromResult(GetAuthenticationState(principal.Claims)));
            }

            return result;
        }

        public async Task SignOut()
        {
            await _localStorage.DeleteAsync(AUTH_TOKEN_NAME);
            NotifyAuthenticationStateChanged(Task.FromResult(GetAuthenticationState(null)));
        }

        #endregion Methods
    }
}
