namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Merchant.TabContents
{
    using Azox.Toolkit.Blazor.Helpers;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Core.Localization;

    using Microsoft.AspNetCore.Components;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;

    public partial class MerchantServeTabContent
    {
        #region Injects

        [Inject]
        private IJsRuntimeHelper JsRuntimeHelper { get; set; }

        [Inject]
        private IMerchantServeService MerchantServeService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        #endregion Injects

        #region Parameters

        [CascadingParameter]
        public MerchantDto Model { get; set; }

        #endregion Parameters

        #region Methods

        protected override void OnParametersSet()
        {
            DataSource = MerchantServeService.Filter<MerchantServeDto>(x => x.Merchant.Id == Model.Id && !x.IsDeleted);
        }

        private void OnEdit(int merchantServeId)
        {
            Navigator.NavigateTo($"/admin/service/{merchantServeId}");
        }

        private async Task OnDelete(int merchantServeId)
        {
            bool confirm = await JsRuntimeHelper.GetConfirmResult(Resources.DeleteConfirm);
            if (confirm)
            {
                await Task.Run(() =>
                {
                    MerchantServeService.Delete(merchantServeId);
                    DataSource = MerchantServeService.Filter<MerchantServeDto>(x => x.Merchant.Id == Model.Id && !x.IsDeleted);
                });
            }
        }

        #endregion Methods

        #region Properties

        private IEnumerable<MerchantServeDto> DataSource { get; set; }

        #endregion Properties
    }
}
