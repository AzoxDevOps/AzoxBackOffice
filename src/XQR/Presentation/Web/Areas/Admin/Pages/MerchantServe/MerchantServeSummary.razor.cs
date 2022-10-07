namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.MerchantServe
{
    using Azox.Business.Core.Extensions;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Web.Areas.Admin.Localization;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.JSInterop;

    using System.Security.Claims;

    [Authorize(Roles = $"{nameof(UserGroupType.Admin)}, {nameof(UserGroupType.MerchantAdmin)}")]
    public partial class MerchantServeSummary
    {
        #region Injects

        [Inject]
        private IJSRuntime JsRuntime { get; set; }

        [Inject]
        private IMerchantServeService MerchantServeService { get; set; }

        [Inject]
        private IMerchantServeUserService MerchantServeUserService { get; set; }

        [Inject]
        private AuthenticationStateProvider AuthStateProvider { get; set; }

        [Inject]
        private NavigationManager Navigation { get; set; }

        #endregion Injects

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            AuthenticationState authenticationState = await AuthStateProvider
                .GetAuthenticationStateAsync();

            string username = authenticationState.User.Identity.Name;
            string userRole = authenticationState.User.FindFirstValue(ClaimTypes.Role);

            if (Enum.TryParse<UserGroupType>(userRole, out UserGroupType userGroupType))
            {
                if (userGroupType == UserGroupType.Admin)
                {
                    DataSource = MerchantServeService.Filter<MerchantServeDto>(x => !x.IsDeleted && !x.Merchant.IsDeleted);
                }
                else if (userGroupType == UserGroupType.MerchantAdmin)
                {
                    DataSource = MerchantServeUserService
                        .Filter(x => x.User.Username == username && !x.Service.IsDeleted && !x.Service.Merchant.IsDeleted)
                        .Select(x => x.Service)
                        .ToDto<MerchantServe, MerchantServeDto>();
                }
                else
                {
                    DataSource = new List<MerchantServeDto>();
                }
            }
        }

        private void Create()
        {
            Navigation.NavigateTo("/admin/service/new");
        }

        private void Edit(int id)
        {
            Navigation.NavigateTo($"/admin/service/{id}");
        }

        private async Task Delete(int id)
        {
            if (await JsRuntime.InvokeAsync<bool>("confirm", Resources.DeleteConfirm))
            {

            }
        }

        #endregion Methods

        #region Properties

        private IEnumerable<MerchantServeDto> DataSource { get; set; }

        #endregion Properties
    }
}
