namespace Azox.XQR.Presentation.Areas.Admin.Pages.Store
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Microsoft.AspNetCore.Components;

    public partial class Create
    {
        #region Injects

        [Inject]
        private IMerchantServeService StoreService { get; set; }

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
        }

        #endregion Methods

        #region Properties

        private MerchantServeDto Model { get; set; }

        #endregion Properties
    }
}
