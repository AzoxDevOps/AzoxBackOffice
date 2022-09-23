namespace Azox.XQR.Presentation.Areas.Admin.Pages.Merchants
{
    using Azox.XQR.Business.Domain.Management;
    using Microsoft.AspNetCore.Components;

    public partial class Detail
    {
        #region Parameters

        [Parameter]
        public MerchantDto Model { get; set; }

        #endregion Parameters
    }
}
