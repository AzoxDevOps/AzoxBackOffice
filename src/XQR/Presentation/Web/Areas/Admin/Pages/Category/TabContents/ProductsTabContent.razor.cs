namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Category.TabContents
{
    using Azox.Toolkit.Blazor.Helpers;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Core.Localization;

    using Microsoft.AspNetCore.Components;

    public partial class ProductsTabContent
    {
        #region Injects

        [Inject]
        private IJsRuntimeHelper JsRuntimeHelper { get; set; }

        [Inject]
        private IProductService ProductService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        #endregion Injects

        #region Parameters

        [CascadingParameter]
        public CategoryDto Model { get; set; }

        #endregion Parameters

        #region Methods

        protected override void OnParametersSet()
        {
            DataSource = ProductService.Filter<ProductDto>(x => x.Category.Id == Model.Id && !x.IsDeleted);
        }

        private void OnEdit(int productId)
        {
            Navigator.NavigateTo($"/admin/product/{productId}");
        }

        private async Task OnDelete(int productId)
        {
            bool confirm = await JsRuntimeHelper.GetConfirmResult(XResource.DeleteConfirm);
            if (confirm)
            {
                await Task.Run(() =>
                {
                    ProductService.Delete(productId);
                    DataSource = ProductService.Filter<ProductDto>(x => x.Category.Id == Model.Id && !x.IsDeleted);
                });
            }
        }

        #endregion Methods

        #region Properties

        public IEnumerable<ProductDto> DataSource { get; set; }

        #endregion Properties
    }
}
