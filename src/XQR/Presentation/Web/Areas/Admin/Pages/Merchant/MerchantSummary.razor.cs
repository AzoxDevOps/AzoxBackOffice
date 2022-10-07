namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Merchant
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Web.Areas.Admin.Localization;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;

    using System.Threading.Tasks;

    [Authorize(Roles = nameof(UserGroupType.Admin))]
    public partial class MerchantSummary
    {
        #region Injects

        [Inject]
        private IJSRuntime JsRuntime { get; set; }

        [Inject]
        private IMerchantService MerchantService { get; set; }

        [Inject]
        private NavigationManager Navigation { get; set; }

        #endregion Injects

        #region Methods

        protected override void OnInitialized()
        {
            DataSource = MerchantService.Filter<MerchantDto>(x => !x.IsDeleted);
        }

        private void Create()
        {
            Navigation.NavigateTo("/admin/merchant/new");
        }

        private void Edit(int id)
        {
            Navigation.NavigateTo($"/admin/merchant/{id}");
        }

        private async Task Delete(int id)
        {
            if (await JsRuntime.InvokeAsync<bool>("confirm", Resources.DeleteConfirm))
            {

            }
        }

        #endregion Methods

        #region Properties

        private IEnumerable<MerchantDto> DataSource { get; set; }

        #endregion Properties
    }
}
