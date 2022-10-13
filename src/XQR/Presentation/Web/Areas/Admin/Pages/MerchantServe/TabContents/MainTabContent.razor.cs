namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.MerchantServe.TabContents
{
    using Azox.XQR.Business.Dto;
    using Microsoft.AspNetCore.Components;

    public partial class MainTabContent
    {
        #region Parameters

        [CascadingParameter]
        public MerchantServeDto Model { get; set; }

        #endregion Parameters
    }
}
