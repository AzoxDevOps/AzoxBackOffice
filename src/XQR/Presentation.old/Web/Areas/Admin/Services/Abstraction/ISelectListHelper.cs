namespace Azox.XQR.Presentation.Web.Areas.Admin.Services
{
    using Microsoft.AspNetCore.Mvc.Rendering;

    /// <summary>
    /// 
    /// </summary>
    public interface ISelectListHelper
    {
        /// <summary>
        /// 
        /// </summary>
        IEnumerable<SelectListItem> GetCategorySelectList();
    }
}
