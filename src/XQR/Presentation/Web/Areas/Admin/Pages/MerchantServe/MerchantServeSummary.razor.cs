namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.MerchantServe
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Web.Areas.Admin.Components;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Components;

    [Authorize(Roles = $"{nameof(UserGroupType.Admin)}, {nameof(UserGroupType.MerchantAdmin)}")]
    public partial class MerchantServeSummary :
        Summary<MerchantServeDto>
    {
        #region Injects

        [Inject]
        private IMerchantServeService MerchantServeService { get; set; }

        #endregion Injects

        #region Methods

        protected override void InitializeDataSource(UserGroupType userGroupType, int merchantId, int serviceId)
        {
            if (userGroupType == UserGroupType.Admin)
            {
                DataSource = MerchantServeService.Filter<MerchantServeDto>(x => !x.IsDeleted);
            }
            else if (userGroupType == UserGroupType.MerchantAdmin)
            {
                DataSource = MerchantServeService.Filter<MerchantServeDto>(x => !x.IsDeleted && x.Merchant.Id == merchantId);
            }
            else if (userGroupType == UserGroupType.MerchantAdmin)
            {
                DataSource = MerchantServeService.Filter<MerchantServeDto>(x => !x.IsDeleted && x.Id == serviceId);
            }
        }

        protected override void OnDelete(int id)
        {

        }

        #endregion Methods

        #region Properties

        protected override string DetailUrl => "service";

        #endregion Properties
    }
}
