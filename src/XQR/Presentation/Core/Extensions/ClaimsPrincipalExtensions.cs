namespace Azox.XQR.Presentation.Core.Extensions
{
    using Azox.Core;
    using Azox.Core.Extensions;
    using Azox.XQR.Business;

    using Microsoft.AspNetCore.Components.Authorization;

    using System.Security.Claims;

    public static class ClaimsPrincipalExtensions
    {
        public const string UserServicesClaimType = "UserServices";

        public static async Task<IEnumerable<int>> GetUserServicesAsync(this Task<AuthenticationState> authenticationState)
        {
            AuthenticationState state = await authenticationState;

            return state.User.GetUserServices();
        }

        public static async Task<UserGroupType> GetUserGroupTypeAsync(this Task<AuthenticationState> authenticationState)
        {
            AuthenticationState state = await authenticationState;

            if (Enum.TryParse<UserGroupType>(state.User.FindFirstValue(ClaimTypes.Role), out UserGroupType userGroupType))
            {
                return userGroupType;
            }

            throw new AzoxBugException();
        }

        public static IEnumerable<int> GetUserServices(this ClaimsPrincipal principal)
        {
            string userServices = principal.FindFirstValue(UserServicesClaimType);
            if (userServices.IsNullOrEmpty())
            {
                return Enumerable.Empty<int>();
            }

            return userServices.Split(",").Select(x => Convert.ToInt32(x));
        }
    }
}
