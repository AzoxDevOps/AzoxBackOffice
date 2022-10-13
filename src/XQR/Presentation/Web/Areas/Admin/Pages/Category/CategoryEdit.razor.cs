namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Category
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;

    using Microsoft.AspNetCore.Components;

    public partial class CategoryEdit
    {
        #region Injects

        [Inject]
        private ICategoryService CategoryService { get; set; }

        #endregion Injects

        #region Parameters

        [Parameter]
        public int CategoryId { get; set; }

        #endregion Parameters

        #region Methods

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (!firstRender)
            {
                if (AuthorizedServiceIds.Any())
                {
                    Model = CategoryService.FirstOrDefault<CategoryDto>(x => x.Id == CategoryId && AuthorizedServiceIds.Contains(x.Service.Id) && !x.IsDeleted);
                }
                else
                {
                    Model = CategoryService.GetById<CategoryDto>(CategoryId);
                }

                StateHasChanged();
            }
        }

        #endregion Methods

        #region Properties

        public CategoryDto Model { get; set; }

        #endregion Properties
    }
}
