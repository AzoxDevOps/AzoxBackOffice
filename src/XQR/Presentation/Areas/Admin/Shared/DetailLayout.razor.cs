namespace Azox.XQR.Presentation.Areas.Admin.Shared
{
    using Microsoft.AspNetCore.Components;

    public partial class DetailLayout
    {
        #region Parameters

        [Parameter]
        public RenderFragment PageToolbar { get; set; }

        [Parameter]
        public RenderFragment PageBody { get; set; }

        [Parameter]
        public string PageTitle { get; set; }

        #endregion Parameters
    }
}
