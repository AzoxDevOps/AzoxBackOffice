namespace Azox.XQR.Presentation.Web.Areas.Admin.Services
{
    using Azox.Core;
    using Azox.Core.Extensions;
    using Azox.Toolkit.Blazor;
    using Azox.XQR.Business;
    using Azox.XQR.Presentation.Core.Configs;

    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
    using Microsoft.IdentityModel.Tokens;

    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Threading.Tasks;

    internal class AuthService :
        AuthenticationStateProvider,
        IAuthService
    {
        #region Fields

        private const string AUTH_TOKEN_NAME = "xqr-auth-token";
        private const string AUTHENTICATION_TYPE = "xqr-auth";

        private readonly SymmetricSecurityKey _symmetricSecurityKey;
        private readonly ProtectedLocalStorage _localStorageService;
        private readonly IUserService _userService;
        private readonly IMerchantServeUserService _merchantServeUserService;

        #endregion Fields

        #region Ctor

        public AuthService(
            JwtConfig jwtConfig,
            ProtectedLocalStorage localStorageService,
            IUserService userService,
            IMerchantServeUserService merchantServeUserService)
        {
            _localStorageService = localStorageService;
            _userService = userService;

            _symmetricSecurityKey = new(jwtConfig.SecretKeyBytes);
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

            return false;
        }

        #endregion Utils

        #region Methods

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                AuthToken authToken = (await _localStorageService
                    .GetAsync<AuthToken>(AUTH_TOKEN_NAME)).Value;

                if (authToken == null)
                {
                    return GetAuthenticationState(null);
                }

                if (authToken.Token.IsNullOrEmpty())
                {
                    return GetAuthenticationState(null);
                }

                if (VerifyToken(authToken.Token, out ClaimsPrincipal? principal))
                {
                    authToken.Token = GetToken(principal);
                    await _localStorageService.SetItemAsync(AUTH_TOKEN_NAME, authToken);
                    return GetAuthenticationState(principal.Claims);
                }

                return GetAuthenticationState(null);
            }
            catch
            {
                return GetAuthenticationState(null);
            }
        }

        public async Task<UserGroupType> GetUserGroupType()
        {
            try
            {
                AuthToken authToken = await _localStorageService
                    .GetItemAsync<AuthToken>(AUTH_TOKEN_NAME);

                return authToken.UserGroupType;
            }
            catch
            {
                throw new AzoxBugException();
            }
        }

        public async Task<int> GetMerchantId()
        {
            try
            {
                AuthToken authToken = await _localStorageService
                    .GetItemAsync<AuthToken>(AUTH_TOKEN_NAME);

                return authToken.MerchantId;
            }
            catch
            {
                throw new AzoxBugException();
            }
        }

        public async Task<int> GetServiceId()
        {
            try
            {
                AuthToken authToken = await _localStorageService
                    .GetItemAsync<AuthToken>(AUTH_TOKEN_NAME);

                return authToken.ServiceId;
            }
            catch
            {
                throw new AzoxBugException();
            }
        }


        public async Task<ValidateCredentialsResult> SignIn(string username, string password)
        {
            ValidateCredentialsResult result = _userService
                .ValidateCredentials(username, password);

            if (result == ValidateCredentialsResult.Succeeded)
            {
                AuthToken authToken = new();
                User user = _userService.GetByUsername(username);
                IEnumerable<MerchantServeUser> serviceUsers = _merchantServeUserService.Filter(x => x.User.Id == user.Id);

                authToken.UserGroupType = user.UserGroup.UserGroupType;
                if (serviceUsers != null && serviceUsers.Any())
                {
                    switch (authToken.UserGroupType)
                    {
                        case UserGroupType.MerchantAdmin:
                            authToken.MerchantId = serviceUsers.FirstOrDefault().Service.Merchant.Id;
                            break;
                        case UserGroupType.ServiceAdmin:
                        case UserGroupType.ServiceUser:
                            authToken.ServiceId = serviceUsers.FirstOrDefault().Service.Id;
                            break;
                        default:
                            throw new AzoxBugException();
                    }
                }

                ClaimsIdentity identity = new(AUTHENTICATION_TYPE);

                identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
                identity.AddClaim(new Claim(ClaimTypes.Role, user.UserGroup.UserGroupType.ToString()));

                ClaimsPrincipal principal = new(identity);

                authToken.Token = GetToken(principal);

                await _localStorageService.SetItemAsync(AUTH_TOKEN_NAME, authToken);

                NotifyAuthenticationStateChanged(Task.FromResult(GetAuthenticationState(principal.Claims)));
            }

            return result;
        }

        public async Task SignOut()
        {
            await _localStorageService.RemoveItemAsync(AUTH_TOKEN_NAME);
            NotifyAuthenticationStateChanged(Task.FromResult(GetAuthenticationState(null)));
        }

        #endregion Methods

        #region Nested

        private class AuthToken
        {
            /// <summary>
            /// 
            /// </summary>
            public string Token { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public UserGroupType UserGroupType { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public int ServiceId { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public int MerchantId { get; set; }
        }

        #endregion Nested
    }
}
