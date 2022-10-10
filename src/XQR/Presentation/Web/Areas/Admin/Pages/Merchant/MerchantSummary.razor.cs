namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Merchant
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Web.Areas.Admin.Components;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Components;

    [Authorize(Roles = nameof(UserGroupType.Admin))]
    public partial class MerchantSummary :
        Summary<MerchantDto>
    {
        #region Injects

        [Inject]
        private IMerchantService MerchantService { get; set; }

        #endregion Injects

        #region Methods

        protected override void InitializeDataSource(UserGroupType userGroupType, int merchantId, int serviceId)
        {
            if (userGroupType == UserGroupType.Admin)
            {
                DataSource = MerchantService.Filter<MerchantDto>(x => !x.IsDeleted);
            }
            else if (userGroupType == UserGroupType.MerchantAdmin)
            {
                DataSource = MerchantService.Filter<MerchantDto>(x => !x.IsDeleted && x.Id == merchantId);
            }
        }

        protected override void OnDelete(int id)
        {

        }

        #endregion Methods

        #region Properties

        protected override string DetailUrl => "merchant";

        #endregion Properties
    }
}
