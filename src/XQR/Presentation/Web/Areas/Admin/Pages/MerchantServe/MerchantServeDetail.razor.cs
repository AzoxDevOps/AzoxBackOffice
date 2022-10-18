namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.MerchantServe
{
    using Azox.Toolkit.Blazor;
    using Azox.Toolkit.Blazor.Helpers;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Core.Localization;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;

    public partial class MerchantServeDetail
    {
        #region Injects

        [Inject]
        private IJsRuntimeHelper JsRuntimeHelper { get; set; }

        [Inject]
        private IMerchantServeService MerchantServeService { get; set; }

        [Inject]
        private ILogger<MerchantServeDetail> Logger { get; set; }

        [Inject]
        private IToastService ToastService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        #endregion Injects

        #region Parameters

        [CascadingParameter]
        public MerchantServeDto Model { get; set; }

        #endregion Parameters

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        private void OnSave(bool saveAndClose)
        {
            try
            {
                if (Model.IsNew)
                {
                    //MerchantServe merchantServe = MerchantServeService
                    //    .Create(merchant.Id, Model.Name, Model.Description, MerchantServeType.Restaurant);

                    //Location location = LocationService
                    //    .Create(merchantServe.Id, Resources.DefaultLocationName);

                    //Navigator.NavigateTo($"/admin/merchant/{merchant.Id}");
                }
                else
                {
                    //Merchant merchant = MerchantServeService.GetById(Model.Id);

                    //merchant.Address = Model.Address;
                    //merchant.Contact = Model.Contact;
                    //merchant.Description = Model.Description;
                    //merchant.FacebookLink = Model.FacebookLink;
                    //merchant.InstagramLink = Model.InstagramLink;
                    //merchant.Name = Model.Name;
                    //merchant.Picture = Model.Picture;

                    //MerchantService.Update(merchant);
                }

                if (!saveAndClose)
                {
                    Navigator.NavigateTo($"/admin/service/{Model.Id}");
                }

                ToastService.ShowSuccess(Resources.SaveSuccessful);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
            }
        }

        private async Task OnDelete()
        {
            bool confirm = await JsRuntimeHelper.GetConfirmResult(Resources.DeleteConfirm);
            if (confirm)
            {
                await Task.Run(() => MerchantServeService.Delete(Model.Id));
                await OnClose();
            }
        }

        private async Task OnClose()
        {
            await Task.Run(() => Navigator.NavigateTo("/admin/service/list"));
        }

        #endregion Methods

        #region Properties

        private EditContext EditContext { get; set; }

        #endregion Properties
    }
}
