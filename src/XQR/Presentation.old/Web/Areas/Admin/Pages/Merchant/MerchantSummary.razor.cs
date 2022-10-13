namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Merchant
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Components;

    [Authorize(Roles = $"{nameof(UserGroupType.Admin)}")]
    public partial class MerchantSummary
    {
        #region Injects

        [Inject]
        private IMerchantService MerchantService { get; set; }

        #endregion Injects

        #region Methods

        protected override void OnInitialized()
        {
            DataSource = MerchantService.Filter<MerchantDto>(x => !x.IsDeleted);
        }

        #endregion Methods

        #region Properties

        private IEnumerable<MerchantDto> DataSource { get; set; }

        #endregion Properties
    }
}
