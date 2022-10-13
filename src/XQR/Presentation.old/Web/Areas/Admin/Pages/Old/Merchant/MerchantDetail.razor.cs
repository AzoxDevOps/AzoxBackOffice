namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Merchant
{
    using Azox.Toolkit.Blazor;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Web.Areas.Admin.Localization;

    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;

    public partial class MerchantDetail
    {
        #region Injects

        [Inject]
        private IJSRuntime JsRuntime { get; set; }

        [Inject]
        private IMerchantService MerchantService { get; set; }

        [Inject]
        private IMerchantServeService MerchantServeService { get; set; }

        [Inject]
        private ILocationService LocationService { get; set; }

        [Inject]
        private IToastService ToastService { get; set; }

        [Inject]
        private NavigationManager Navigation { get; set; }

        #endregion Injects

        #region Parameters

        [CascadingParameter]
        public MerchantDto Model { get; set; }

        #endregion Parameters

        #region Methods

        private void Save()
        {
            if (Model.IsNew)
            {
                Merchant merchant = MerchantService
                    .Create(Model.Name, Model.Description, Model.MerchantType);

                MerchantServe merchantServe = MerchantServeService
                    .Create(merchant.Id, Model.Name, Model.Description, MerchantServeType.Restaurant);

                LocationService.Create(merchantServe.Id, Model.Name);

                ToastService.ShowSuccess(Resources.Recorded);

                Navigation.NavigateTo($"/admin/merchant/{merchant.Id}");
            }
            else
            {
                Merchant merchant = MerchantService.GetById(Model.Id);

                merchant.Name = Model.Name;
                merchant.Description = Model.Description;

                merchant.Contact = new Contact
                {
                    Name = Model.Contact.Name,
                    Phone = Model.Contact.Phone,
                    Email = Model.Contact.Email
                };

                merchant.Picture = new Picture
                {
                    FileName = Model.Picture.FileName
                };

                MerchantService.Update(merchant);
                ToastService.ShowSuccess(Resources.Updated);
                StateHasChanged();
            }
        }

        private void SaveAndClose()
        {
            Save();
            Close();
        }

        private async Task Delete()
        {
            if (await JsRuntime.InvokeAsync<bool>("confirm", Resources.DeleteConfirm))
            {
                MerchantService.Delete(Model.Id);
                Close();
            }
        }

        private void Close()
        {
            Navigation.NavigateTo("/admin/merchants");
        }

        #endregion Methods
    }
}
