namespace Azox.XQR.Presentation.Web.Areas.Admin.Components
{
    using Microsoft.AspNetCore.Components;

    public partial class GenericDetail
    {
        #region Parameters

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public RenderFragment MobileTemplate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public string PageTitle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public RenderFragment Template { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public RenderFragment ToolbarTemplate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public RenderFragment MobileToolbarTemplate { get; set; }

        #endregion Parameters
    }
}
