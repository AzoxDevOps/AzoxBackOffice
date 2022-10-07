﻿namespace Azox.XQR.Presentation.Web.Areas.Admin.Services
{
    using Azox.Core.Extensions;
    using Azox.XQR.Business;
    using Azox.XQR.Presentation.Web.Areas.Admin.Configs;

    using Microsoft.AspNetCore.Components.Authorization;
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
        private readonly ILocalStorageService _localStorageService;
        private readonly IUserService _userService;

        #endregion Fields

        #region Ctor

        public AuthService(
            JwtConfig jwtConfig,
            ILocalStorageService localStorageService,
            IUserService userService)
        {
            _localStorageService = localStorageService;
            _userService = userService;

            _symmetricSecurityKey = new(jwtConfig.SecretKeyBytes);
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
                string token = await _localStorageService
                    .GetItemAsStringAsync(AUTH_TOKEN_NAME);

                if (token.IsNullOrEmpty())
                {
                    return GetAuthenticationState(null);
                }

                if (VerifyToken(token, out ClaimsPrincipal? principal))
                {
                    token = GetToken(principal);
                    await _localStorageService.SetItemAsStringAsync(AUTH_TOKEN_NAME, token);
                    return GetAuthenticationState(principal.Claims);
                }

                return GetAuthenticationState(null);
            }
            catch
            {
                return GetAuthenticationState(null);
            }
        }

        public async Task<ValidateCredentialsResult> SignIn(string username, string password)
        {
            ValidateCredentialsResult result = _userService
                .ValidateCredentials(username, password);

            if (result == ValidateCredentialsResult.Succeeded)
            {
                User user = _userService.GetByUsername(username);

                ClaimsIdentity identity = new(AUTHENTICATION_TYPE);

                identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
                identity.AddClaim(new Claim(ClaimTypes.Role, user.UserGroup.UserGroupType.ToString()));

                ClaimsPrincipal principal = new(identity);

                string token = GetToken(principal);

                await _localStorageService.SetItemAsStringAsync(AUTH_TOKEN_NAME, token);

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
    }
}
