namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.MerchantServe
{
    using Azox.Toolkit.Blazor;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Core.Localization;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;

    public partial class MerchantServeDetail
    {
        #region Injects

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
            EditContext = new(Model);
        }

        private void OnSave()
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

                ToastService.ShowSuccess(Resources.SaveSuccessful);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
            }
        }

        private async Task OnDelete()
        {
            await Task.CompletedTask;
        }

        private void OnClose()
        {
            Navigator.NavigateTo("/admin/service/list");
        }

        #endregion Methods

        #region Properties

        private EditContext EditContext { get; set; }

        #endregion Properties
    }
}
