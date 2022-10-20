namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Product
{
    using Azox.Core.Extensions;
    using Azox.Toolkit.Blazor.Helpers;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Core.Localization;

    using Microsoft.AspNetCore.Components;

    using System.Linq.Expressions;

    public partial class ProductSummary
    {
        #region Injects

        [Inject]
        private IJsRuntimeHelper JsRuntimeHelper { get; set; }

        [Inject]
        private IProductService ProductService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        #endregion Injects

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            FilterDataSource(x => !x.IsDeleted);
        }

        private void FilterDataSource(Expression<Func<Product, bool>> predicate)
        {
            if (UserServices.Any())
            {
                predicate = predicate.And(x => UserServices.Contains(x.Category.Service.Id));
            }

            DataSource = ProductService.Filter<ProductDto>(predicate);
        }

        private void OnSearch()
        {
            Expression<Func<Product, bool>> predicate = x => !x.IsDeleted;

            FilterDataSource(predicate);
        }

        private void OnCreate()
        {
            Navigator.NavigateTo("/admin/product/new");
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
                    FilterDataSource(x => !x.IsDeleted);
                });
            }
        }

        #endregion Methods

        #region Properties

        private IEnumerable<ProductDto> DataSource { get; set; }

        #endregion Properties
    }
}
