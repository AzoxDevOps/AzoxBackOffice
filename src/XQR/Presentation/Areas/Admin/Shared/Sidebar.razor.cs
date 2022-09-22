namespace Azox.XQR.Presentation.Areas.Admin.Shared
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Domain.Management;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;
    using System.Threading.Tasks;

    public partial class Sidebar
    {
        #region Injects

        [Inject]
        AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        IUserService UserService { get; set; }

        #endregion Injects

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            AuthenticationState authenticationState = await AuthenticationStateProvider
                .GetAuthenticationStateAsync();

            UserGroupType = (await UserService.GetByUsernameAsync(authenticationState.User.Identity.Name)).UserGroup.UserGroupType;
        }

        #endregion Methods

        #region Properties

        UserGroupType UserGroupType { get; set; }

        #endregion Properties
    }
}
