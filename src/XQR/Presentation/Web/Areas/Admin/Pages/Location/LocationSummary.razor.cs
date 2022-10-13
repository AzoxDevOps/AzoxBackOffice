namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Location
{
    using Azox.Core.Extensions;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;

    using Microsoft.AspNetCore.Components;

    using System.Linq.Expressions;

    public partial class LocationSummary
    {
        #region Injects

        [Inject]
        private ILocationService LocationService { get; set; }

        #endregion Injects

        #region Methods

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (!firstRender)
            {
                if (AuthorizedServiceIds.Any())
                {
                    DataSource = LocationService.Filter<LocationDto>(x => !x.IsDeleted && AuthorizedServiceIds.Contains(x.Service.Id));
                }
                else
                {
                    DataSource = LocationService.Filter<LocationDto>(x => !x.IsDeleted);
                }
                StateHasChanged();
            }
        }

        private void OnSearch()
        {
            Expression<Func<Location, bool>> predicate = x => !x.IsDeleted;

            if (AuthorizedServiceIds.Any())
            {
                predicate = predicate.And(x => AuthorizedServiceIds.Contains(x.Service.Id));
            }

            DataSource = LocationService.Filter<LocationDto>(predicate);
        }

        #endregion Methods

        #region Properties

        public IEnumerable<LocationDto> DataSource { get; set; }

        #endregion Properties
    }
}
