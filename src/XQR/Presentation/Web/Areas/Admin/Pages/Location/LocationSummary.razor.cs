namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Location
{
    using Azox.Core.Extensions;
    using Azox.Toolkit.Blazor.Helpers;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Core.Localization;

    using Microsoft.AspNetCore.Components;

    using System.Linq.Expressions;

    public partial class LocationSummary
    {
        #region Injects

        [Inject]
        private IJsRuntimeHelper JsRuntimeHelper { get; set; }

        [Inject]
        private ILocationService LocationService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        #endregion Injects

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            FilterDataSource(x => !x.IsDeleted);
        }

        private void FilterDataSource(Expression<Func<Location, bool>> predicate)
        {
            if (UserServices.Any())
            {
                predicate = predicate.And(x => UserServices.Contains(x.Service.Id));
            }

            DataSource = LocationService.Filter<LocationDto>(predicate);
        }

        private void OnSearch()
        {
            Expression<Func<Location, bool>> predicate = x => !x.IsDeleted && !x.Service.IsDeleted;

            FilterDataSource(predicate);
        }

        private void OnCreate()
        {
            Navigator.NavigateTo("/admin/location/new");
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
                    FilterDataSource(x => !x.IsDeleted);
                });
            }
        }

        #endregion Methods

        #region Properties

        public IEnumerable<LocationDto> DataSource { get; set; }

        #endregion Properties
    }
}
