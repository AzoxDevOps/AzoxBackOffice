namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Merchant
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Web.Areas.Admin.Localization;

    using Microsoft.AspNetCore.Components;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using Microsoft.JSInterop;

    public partial class Detail_Locations
    {
        #region Injects

        [Inject]
        private IJSRuntime JsRuntime { get; set; }

        [Inject]
        private ILocationService LocationService { get; set; }

        [Inject]
        private NavigationManager Navigation { get; set; }

        #endregion Injects

        #region Parameters

        [CascadingParameter]
        public MerchantDto Model { get; set; }

        #endregion Parameters

        #region Methods

        protected override void OnInitialized()
        {
            DataSource = LocationService.Filter<LocationDto>(x => !x.IsDeleted && x.Service.Merchant.Id == Model.Id);
        }

        private void Edit(int id)
        {
            Navigation.NavigateTo($"/admin/location/{id}");
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
