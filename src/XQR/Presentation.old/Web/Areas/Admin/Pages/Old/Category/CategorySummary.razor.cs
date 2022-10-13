namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Category
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Web.Areas.Admin.Components;

    using Microsoft.AspNetCore.Components;

    public partial class CategorySummary
    {
        #region Injects

        [Inject]
        private ICategoryService CategoryService { get; set; }

        #endregion Injects
    }
}

