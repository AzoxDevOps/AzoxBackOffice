namespace Azox.XQR.Presentation.Web.Areas.Admin.Shared
{
    using Azox.XQR.Business;
    using Azox.XQR.Presentation.Core.Auth;
    using Azox.XQR.Presentation.Web.Areas.Admin.Sitemap;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;

    using System.Security.Claims;

    public partial class AdminHeader
    {
        #region Fields

        private UserGroupType _userGroupType;

        #endregion Fields

        #region Injects

        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        [Inject]
        private MenuItemService MenuItemService { get; set; }

        #endregion Injects

        #region Methods

        protected override void OnInitialized()
        {
            MenuItems = new()
            {
                Items = new()
            };
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                AuthenticationState authenticationState = await AuthenticationStateProvider
                       .GetAuthenticationStateAsync();

                string role = authenticationState.User.FindFirstValue(ClaimTypes.Role);

                if (Enum.TryParse<UserGroupType>(role, out _userGroupType))
                {
                    MenuItems = await MenuItemService.GetMenuItemContext();
                    StateHasChanged();
                }
            }
        }

        private async Task SignOut()
        {
            await ((IAuthService)AuthenticationStateProvider).SignOut();
        }

        #endregion Methods

        #region Properties

        private MenuItemContext MenuItems { get; set; }

        #endregion Properties
    }
}
