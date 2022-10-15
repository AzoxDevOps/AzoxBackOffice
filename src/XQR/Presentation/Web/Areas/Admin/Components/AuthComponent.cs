namespace Azox.XQR.Presentation.Web.Areas.Admin.Components
{
    using Azox.XQR.Business;
    using Azox.XQR.Presentation.Core.Extensions;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;

    public partial class AuthComponent :
        ComponentBase
    {
        #region Parameters

        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationState { get; set; }

        #endregion Parameters

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            UserGroupType = await AuthenticationState.GetUserGroupTypeAsync();
            UserServices = await AuthenticationState.GetUserServicesAsync();
        }

        #endregion Methods

        #region Properties

        protected UserGroupType UserGroupType { get; private set; }

        protected IEnumerable<int> UserServices { get; private set; }

        #endregion Properties
    }
}
