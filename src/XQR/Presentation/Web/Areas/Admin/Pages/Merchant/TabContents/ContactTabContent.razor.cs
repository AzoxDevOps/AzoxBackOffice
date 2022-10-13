namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Merchant.TabContents
{
    using Azox.XQR.Business.Dto;

    using Microsoft.AspNetCore.Components;

    public partial class ContactTabContent
    {
        #region Parameters

        [CascadingParameter]
        public MerchantDto Model { get; set; }

        #endregion Parameters
    }
}
