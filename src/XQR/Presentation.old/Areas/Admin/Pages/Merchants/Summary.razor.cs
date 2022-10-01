namespace Azox.XQR.Presentation.Areas.Admin.Pages.Merchants
{
    using Azox.XQR.Presentation.Areas.Admin.Models;
    using Azox.XQR.Presentation.Areas.Admin.Services;
    using Microsoft.AspNetCore.Components;
    using System.Threading.Tasks;

    public partial class Summary
    {
        #region Injects

        [Inject]
        IMerchantModelFactory MerchantModelFactory { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        #endregion Injects

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            Model = await MerchantModelFactory.PrepareSummaryModelAsync();
        }

        #endregion Methods

        #region Properties

        private IEnumerable<MerchantModel> Model { get; set; }

        #endregion Properties
    }
}
