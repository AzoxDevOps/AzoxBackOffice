namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Location
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Web.Areas.Admin.Components;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Components;

    [Authorize(Roles = $"{nameof(UserGroupType.Admin)}, {nameof(UserGroupType.MerchantAdmin)}, {nameof(UserGroupType.ServiceAdmin)}")]
    public partial class LocationSummary :
        Summary<LocationDto>
    {
        #region Injects

        [Inject]
        private ILocationService LocationService { get; set; }

        #endregion Injects

        #region Methods

        protected override void InitializeDataSource(UserGroupType userGroupType, int merchantId, int serviceId)
        {
            if (userGroupType == UserGroupType.Admin)
            {
                DataSource = LocationService.Filter<LocationDto>(x => !x.IsDeleted);
            }
            else if (userGroupType == UserGroupType.MerchantAdmin)
            {
                DataSource = LocationService.Filter<LocationDto>(x => !x.IsDeleted && x.Service.Merchant.Id == merchantId);
            }
            else
            {
                DataSource = LocationService.Filter<LocationDto>(x => !x.IsDeleted && x.Service.Id == serviceId);
            }
        }

        protected override void OnDelete(int id)
        {
            
        }

        #endregion Methods

        #region Properties

        protected override string DetailUrl => "location";

        #endregion Properties
    }
}
