namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.MerchantServe.TabContents
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Core.Extensions;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public partial class MainTabContent
    {
        #region Parameters

        [CascadingParameter]
        public MerchantServeDto Model { get; set; }

        #endregion Parameters

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        #endregion Methods
    }
}
