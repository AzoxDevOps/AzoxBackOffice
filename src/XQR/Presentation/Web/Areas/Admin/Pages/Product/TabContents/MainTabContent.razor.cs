namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Product.TabContents
{
    using Azox.Core.Extensions;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;

    using Microsoft.AspNetCore.Components;

    using System.Linq.Expressions;

    public partial class MainTabContent
    {
        #region Injects

        [Inject]
        private ICategoryService CategoryService { get; set; }

        #endregion Injects

        #region Parameters

        [CascadingParameter]
        public ProductDto Model { get; set; }

        #endregion Parameters

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            FillCategories();
        }

        private void FillCategories()
        {
            Expression<Func<Category, bool>> predicate = x => !x.IsDeleted;

            if (UserGroupType != UserGroupType.Admin)
            {
                predicate = predicate.And(x => UserServices.Contains(x.Service.Id));
            }

            Categories = CategoryService.Filter<CategoryDto>(predicate);
        }

        private void CategoryOnSelect(object selectedCategory)
        {
            Model.Category = (CategoryDto)selectedCategory;
        }

        #endregion Methods

        #region Properties

        private CategoryDto SelectedCategory { get; set; }

        private IEnumerable<CategoryDto> Categories { get; set; }

        #endregion Properties
    }
}
