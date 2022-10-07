namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Location
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Web.Areas.Admin.Localization;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.JSInterop;

    using System.Data;
    using System.Security.Claims;

    [Authorize(Roles = $"{nameof(UserGroupType.Admin)}, {nameof(UserGroupType.MerchantAdmin)}, {nameof(UserGroupType.ServiceAdmin)}")]
    public partial class LocationSummary
    {
        #region Injects

        [Inject]
        private IJSRuntime JsRuntime { get; set; }

        [Inject]
        private ILocationService LocationService { get; set; }

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
                    DataSource = LocationService.Filter<LocationDto>(x => !x.IsDeleted);
                }
                else if (userGroupType == UserGroupType.MerchantAdmin
                    || userGroupType == UserGroupType.ServiceAdmin)
                {
                    IEnumerable<MerchantServe> userServices = MerchantServeUserService
                        .Filter(x => x.User.Username == username)
                        .Select(x => x.Service);

                    List<LocationDto> locations = new();

                    foreach (MerchantServe service in userServices)
                    {
                        locations.AddRange(LocationService.Filter<LocationDto>(x => !x.IsDeleted && x.Service.Id == service.Id));
                    }

                    DataSource = locations;
                }
                else
                {
                    DataSource = new List<LocationDto>();
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

        private IEnumerable<LocationDto> DataSource { get; set; }

        #endregion Properties
    }
}
