namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Product
{
    using Azox.Toolkit.Blazor;
    using Azox.Toolkit.Blazor.Helpers;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Core.Localization;

    using Microsoft.AspNetCore.Components;

    public partial class ProductDetail
    {
        #region Injects

        [Inject]
        private IJsRuntimeHelper JsRuntimeHelper { get; set; }

        [Inject]
        private IProductService ProductService { get; set; }

        [Inject]
        private ILogger<ProductDetail> Logger { get; set; }

        [Inject]
        private IToastService ToastService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        #endregion Injects

        #region Parameters

        [CascadingParameter]
        public ProductDto Model { get; set; }

        #endregion Parameters

        #region Methods

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        private void OnSave(bool saveAndClose)
        {
            try
            {
                if (Model.IsNew)
                {



                }
                else
                {

                }

                if (!saveAndClose)
                {
                    Navigator.NavigateTo($"/admin/product/{Model.Id}");
                }

                ToastService.ShowSuccess(XResource.SaveSuccessful);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
            }
        }

        private async Task OnDelete()
        {
            bool confirm = await JsRuntimeHelper.GetConfirmResult(XResource.DeleteConfirm);
            if (confirm)
            {
                await Task.Run(() => ProductService.Delete(Model.Id));
                await OnClose();
            }
        }

        private async Task OnClose()
        {
            await Task.Run(() => Navigator.NavigateTo("/admin/category/list"));
        }

        #endregion Methods
    }
}
