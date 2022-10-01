namespace Azox.XQR.Presentation.Areas.Admin.Pages.Store
{
    using Azox.XQR.Business.Dto;
    using Microsoft.AspNetCore.Components;

    public partial class _Info
    {
        #region Parameters

        [Parameter]
        public MerchantServeDto Model { get; set; }

        [Parameter]
        public bool IsNew { get; set; }

        #endregion Parameters
    }
}
