namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Category
{
    using Azox.Core.Extensions;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;

    using Microsoft.AspNetCore.Components;

    using System.Linq.Expressions;

    public partial class CategorySummary
    {
        #region Injects

        [Inject]
        private ICategoryService CategoryService { get; set; }

        [Inject]
        private NavigationManager Navigation { get; set; }

        #endregion Injects

        #region Methods

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (!firstRender)
            {
                if (DataSource == null)
                {
                    if (AuthorizedServiceIds.Any())
                    {
                        DataSource = CategoryService.Filter<CategoryDto>(x => !x.IsDeleted && AuthorizedServiceIds.Contains(x.Service.Id));
                    }
                    else
                    {
                        DataSource = CategoryService.Filter<CategoryDto>(x => !x.IsDeleted);
                    }

                    StateHasChanged();
                }
            }
        }

        private void OnSearch()
        {
            Expression<Func<Category, bool>> predicate = x => !x.IsDeleted;
            if (AuthorizedServiceIds.Any())
            {
                predicate = predicate.And(x => AuthorizedServiceIds.Contains(x.Service.Id));
            }

            DataSource = CategoryService.Filter<CategoryDto>(predicate);
        }

        private void OnCreate()
        {
            Navigation.NavigateTo("/admin/category/new");
        }

        #endregion Methods

        #region Properties

        public IEnumerable<CategoryDto> DataSource { get; set; }

        #endregion Properties
    }
}
