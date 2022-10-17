namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Category
{
    using Azox.Core.Extensions;
    using Azox.Toolkit.Blazor.Helpers;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Core.Localization;

    using Microsoft.AspNetCore.Components;

    using System.Linq.Expressions;

    public partial class CategorySummary
    {
        #region Injects

        [Inject]
        private IJsRuntimeHelper JsRuntimeHelper { get; set; }

        [Inject]
        private ICategoryService CategoryService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        #endregion Injects

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            FilterDataSource(x => !x.IsDeleted && !x.Service.IsDeleted);
        }

        private void FilterDataSource(Expression<Func<Category, bool>> predicate)
        {
            if (UserServices.Any())
            {
                predicate = predicate.And(x => UserServices.Contains(x.Service.Id));
            }

            DataSource = CategoryService.Filter<CategoryDto>(predicate);
        }

        private void OnSearch()
        {
            Expression<Func<Category, bool>> predicate = x => !x.IsDeleted && !x.Service.IsDeleted;

            FilterDataSource(predicate);
        }

        private void OnCreate()
        {
            Navigator.NavigateTo("/admin/category/new");
        }

        private void OnEdit(int categoryId)
        {
            Navigator.NavigateTo($"/admin/category/{categoryId}");
        }

        private async Task OnDelete(int locationId)
        {
            bool confirm = await JsRuntimeHelper.GetConfirmResult(Resources.DeleteConfirm);
            if (confirm)
            {
                await Task.Run(() =>
                {
                    CategoryService.Delete(locationId);
                    FilterDataSource(x => !x.IsDeleted && !x.Service.IsDeleted);
                });
            }
        }

        #endregion Methods

        #region Properties

        private IEnumerable<CategoryDto> DataSource { get; set; }

        #endregion Properties
    }
}
