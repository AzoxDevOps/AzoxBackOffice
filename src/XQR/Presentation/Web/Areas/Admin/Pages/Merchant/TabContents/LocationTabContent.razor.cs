namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Merchant.TabContents
{
    using Azox.Toolkit.Blazor.Helpers;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Core.Localization;

    using Microsoft.AspNetCore.Components;

    using System;
    using System.Linq.Expressions;

    public partial class LocationTabContent
    {
        #region Injects

        [Inject]
        private IJsRuntimeHelper JsRuntimeHelper { get; set; }

        [Inject]
        private ILocationService LocationService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        #endregion Injects

        #region Parameters

        [CascadingParameter]
        public MerchantDto Model { get; set; }

        #endregion Parameters

        #region Methods

        protected override void OnParametersSet()
        {
            DataSource = LocationService.Filter<LocationDto>(x => x.Service.Merchant.Id == Model.Id && !x.IsDeleted && !x.Service.IsDeleted);
        }

        private void OnEdit(int locationId)
        {
            Navigator.NavigateTo($"/admin/location/{locationId}");
        }

        private async Task OnDelete(int locationId)
        {
            bool confirm = await JsRuntimeHelper.GetConfirmResult(Resources.DeleteConfirm);
            if (confirm)
            {
                await Task.Run(() =>
                {
                    LocationService.Delete(locationId);
                    DataSource = LocationService.Filter<LocationDto>(x => x.Service.Merchant.Id == Model.Id && !x.IsDeleted && !x.Service.IsDeleted);
                });
            }
        }

        #endregion Methods

        #region Properties

        public IEnumerable<LocationDto> DataSource { get; set; }

        #endregion Properties
    }
}
