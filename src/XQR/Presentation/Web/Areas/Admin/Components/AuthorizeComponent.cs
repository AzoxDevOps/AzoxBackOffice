namespace Azox.XQR.Presentation.Web.Areas.Admin.Components
{
    using Azox.XQR.Business;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;

    using System.Security.Claims;

    public partial class AuthorizeComponent :
        ComponentBase
    {
        #region Injects

        [Inject]
        private IMerchantServeUserService MerchantServeUserService { get; set; }

        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        protected NavigationManager Navigator { get; set; }

        #endregion Injects

        #region Utils

        private async Task SetAuthorizedServiceIds()
        {
            AuthenticationState authenticationState = await AuthenticationStateProvider
                    .GetAuthenticationStateAsync();

            string username = authenticationState.User.Identity.Name;
            if (Enum.TryParse<UserGroupType>(authenticationState.User.FindFirstValue(ClaimTypes.Role), out UserGroupType userGroupType))
            {
                UserGroupType = userGroupType;
            }

            AuthorizedServiceIds = MerchantServeUserService
                .Filter(x => x.User.Username == username)
                .Select(x => x.Service.Id);

            StateHasChanged();
        }

        #endregion Utils

        #region Methods

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await SetAuthorizedServiceIds();
            }
        }

        #endregion Methods

        #region Properties

        protected UserGroupType UserGroupType { get; private set; }

        protected IEnumerable<int> AuthorizedServiceIds { get; private set; }

        #endregion Properties
    }
}
