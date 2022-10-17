namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Category.TabContents
{
    using Azox.XQR.Business.Dto;

    using Microsoft.AspNetCore.Components;

    public partial class MainTabContent
    {
        #region Parameters

        [CascadingParameter]
        public CategoryDto Model { get; set; }

        #endregion Parameters
    }
}
