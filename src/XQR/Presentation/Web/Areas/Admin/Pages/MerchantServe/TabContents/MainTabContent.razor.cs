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
        #region Injects

        [Inject]
        private IMerchantService MerchantService { get; set; }

        [Inject]
        private IMerchantServeService MerchantServeService { get; set; }

        #endregion Injects

        #region Parameters

        [CascadingParameter]
        public MerchantServeDto Model { get; set; }

        #endregion Parameters

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if (UserGroupType == UserGroupType.Admin)
            {
                MerchantSelectList = MerchantService
                    .Filter(x => !x.IsDeleted)
                    .Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    });
            }
            else
            {
                MerchantSelectList = MerchantServeService
                    .Filter(x => !x.IsDeleted && UserServices.Contains(x.Id))
                    .Select(x => new SelectListItem
                    {
                        Text = x.Merchant.Name,
                        Value = x.Merchant.Id.ToString()
                    });
            }
        }

        #endregion Methods

        #region Properties

        private IEnumerable<SelectListItem> MerchantSelectList { get; set; }

        #endregion Properties
    }
}
