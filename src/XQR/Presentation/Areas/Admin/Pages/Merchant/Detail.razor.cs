namespace Azox.XQR.Presentation.Areas.Admin.Pages.Merchant
{
    using Azox.XQR.Business.Dto;
    using Microsoft.AspNetCore.Components;

    public partial class Detail
    {
        #region Parameters

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public MerchantDto Model { get; set; }

        [Parameter]
        public bool IsNew { get; set; }

        #endregion Parameters
    }
}
