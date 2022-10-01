namespace Azox.XQR.Presentation.Areas.Admin.Pages.Merchant
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Microsoft.AspNetCore.Components;
    using System.Threading.Tasks;

    public partial class Create
    {
        #region Injects

        [Inject]
        private IMerchantService MerchantService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        #endregion Injects

        #region Methods

        protected override void OnInitialized()
        {
            Model = new();
        }

        private async Task SaveAsync()
        {
            await Task.CompletedTask;

            //NavigationManager.NavigateTo($"/admin/merchant/{merchant.Id}", true);
        }

        #endregion Methods

        #region Properties

        private MerchantDto Model { get; set; }

        #endregion Properties
    }
}
