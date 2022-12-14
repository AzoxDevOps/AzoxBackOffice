namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Merchant
{
    using Azox.Toolkit.Blazor;
    using Azox.Toolkit.Blazor.Helpers;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Core.Localization;

    using Microsoft.AspNetCore.Components;

    public partial class MerchantDetail
    {
        #region Injects

        [Inject]
        private IJsRuntimeHelper JsRuntimeHelper { get; set; }

        [Inject]
        private IMerchantService MerchantService { get; set; }

        [Inject]
        private ILogger<MerchantDetail> Logger { get; set; }

        [Inject]
        private IToastService ToastService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        #endregion Injects

        #region Parameters

        [CascadingParameter]
        public MerchantDto Model { get; set; }

        #endregion Parameters

        #region Methods

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        private void OnSave(bool saveAndClose)
        {
            try
            {
                if (Model.IsNew)
                {
                    Merchant merchant = MerchantService
                        .Create(Model.Name, Model.Description, Model.MerchantType);

                    Model.Id = merchant.Id;
                }
                else
                {
                    Merchant merchant = MerchantService.GetById(Model.Id);

                    merchant.Address = Model.Address;
                    merchant.Contact = Model.Contact;
                    merchant.Description = Model.Description;
                    merchant.FacebookLink = Model.FacebookLink;
                    merchant.InstagramLink = Model.InstagramLink;
                    merchant.Name = Model.Name;
                    merchant.Picture = Model.Picture;

                    MerchantService.Update(merchant);
                }

                if (!saveAndClose)
                {
                    Navigator.NavigateTo($"/admin/merchant/{Model.Id}");
                }

                ToastService.ShowSuccess(XResource.SaveSuccessful);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
            }
        }

        private async Task OnDelete()
        {
            bool confirm = await JsRuntimeHelper.GetConfirmResult(XResource.DeleteConfirm);
            if (confirm)
            {
                await Task.Run(() => MerchantService.Delete(Model.Id));
                await OnClose();
            }
        }

        private async Task OnClose()
        {
            await Task.Run(() => Navigator.NavigateTo("/admin/merchant/list"));
        }

        #endregion Methods
    }
}
