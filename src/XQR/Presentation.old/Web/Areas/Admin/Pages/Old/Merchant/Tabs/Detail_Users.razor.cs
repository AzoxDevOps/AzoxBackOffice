namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Merchant
{
    using Azox.Business.Core.Extensions;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Web.Areas.Admin.Localization;

    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;

    public partial class Detail_Users
    {
        #region Injects

        [Inject]
        private IJSRuntime JsRuntime { get; set; }

        [Inject]
        private IUserService UserService { get; set; }

        [Inject]
        private IMerchantServeUserService MerchantServeUserService { get; set; }

        [Inject]
        private NavigationManager Navigation { get; set; }

        #endregion Injects

        #region Parameters

        [CascadingParameter]
        public MerchantDto Model { get; set; }

        #endregion Parameters

        #region Methods

        protected override void OnInitialized()
        {
            DataSource = MerchantServeUserService
                .Filter(x => x.Service.Merchant.Id == Model.Id)
                .Select(x => x.User)
                .ToDto<User, UserDto>();
        }

        private void Edit(int id)
        {
            Navigation.NavigateTo($"/admin/location/{id}");
        }

        private async Task Delete(int id)
        {
            if (await JsRuntime.InvokeAsync<bool>("confirm", Resources.DeleteConfirm))
            {

            }
        }

        #endregion Methods

        #region Properties

        private IEnumerable<UserDto> DataSource { get; set; }

        #endregion Properties
    }
}
