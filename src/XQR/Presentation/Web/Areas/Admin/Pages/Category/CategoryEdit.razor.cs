namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Category
{
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Business;
    using Microsoft.AspNetCore.Components;

    public partial class CategoryEdit
    {
        #region Injects

        [Inject]
        private ICategoryService CategoryService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        #endregion

        #region Parameters

        [Parameter]
        public int CategoryId { get; set; }

        #endregion Parameters

        #region Methods

        protected override void OnParametersSet()
        {
            base.OnInitialized();
            Model = CategoryService.GetById<CategoryDto>(CategoryId);

            if (Model.IsDeleted)
            {
                Navigator.NavigateTo("/admin/category/list");
            }
        }

        #endregion Methods

        #region Properties

        public CategoryDto Model { get; set; }

        #endregion Properties
    }
}
