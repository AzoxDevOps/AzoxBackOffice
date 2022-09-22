namespace Azox.XQR.Presentation.Areas.Admin.Pages.Merchants
{
    using Azox.XQR.Business.Domain.Management;
    using Azox.XQR.Business.Service.Management;
    using Microsoft.AspNetCore.Components;
    using System.Threading.Tasks;

    public partial class MerchantSummary
    {
        #region Injects

        [Inject]
        IMerchantService MerchantService { get; set; }

        #endregion Injects

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Merchants = await MerchantService.GetAllMerchantsAsync();
            }
            catch(Exception ex)
            {

            }
        }

        #endregion Methods

        #region Properties

        private IEnumerable<Merchant> Merchants { get; set; }

        #endregion Properties
    }
}
