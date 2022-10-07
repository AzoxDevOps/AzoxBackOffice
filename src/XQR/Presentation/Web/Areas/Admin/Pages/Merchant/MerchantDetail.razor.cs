namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Merchant
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Web.Areas.Admin.Localization;

    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;

    public partial class MerchantDetail
    {
        #region Injects

        [Inject]
        private IJSRuntime JsRuntime { get; set; }

        [Inject]
        private IMerchantService MerchantService { get; set; }

        [Inject]
        private NavigationManager Navigation { get; set; }

        #endregion Injects

        #region Parameters

        [CascadingParameter]
        public MerchantDto Model { get; set; }

        #endregion Parameters

        #region Methods

        private void Save()
        {

        }

        private void SaveAndClose()
        {
            Save();
            Close();
        }

        private async Task Delete()
        {
            if (await JsRuntime.InvokeAsync<bool>("confirm", Resources.DeleteConfirm))
            {
                MerchantService.Delete(Model.Id);
                Close();
            }
        }

        private void Close()
        {
            Navigation.NavigateTo("/admin/merchants");
        }

        #endregion Methods
    }
}
