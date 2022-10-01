namespace Azox.XQR.Presentation.Areas.Admin.Pages.Merchant
{
    using Azox.Core.Extensions;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public partial class _Stores
    {
        #region Injects

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        #endregion Injects

        #region Parameters

        [Parameter]
        public MerchantDto Model { get; set; }

        #endregion Parameters
    }
}
