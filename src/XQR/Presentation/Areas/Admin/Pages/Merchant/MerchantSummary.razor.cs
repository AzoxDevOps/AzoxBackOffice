namespace Azox.XQR.Presentation.Areas.Admin.Pages.Merchant
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Microsoft.AspNetCore.Components;
    using System.Threading.Tasks;

    public partial class MerchantSummary
    {
        #region Injects

        [Inject]
        private IMerchantService MerchantService { get; set; }

        #endregion Injects

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            DataSource = await MerchantService.GetAllAsync<MerchantDto>();
        }

        #endregion Methods

        #region Properties

        private IEnumerable<MerchantDto> DataSource { get; set; }

        #endregion Properties
    }
}
