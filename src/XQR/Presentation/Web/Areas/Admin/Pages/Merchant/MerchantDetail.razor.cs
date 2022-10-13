﻿namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Merchant
{
    using Azox.Toolkit.Blazor;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Core.Localization;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;

    public partial class MerchantDetail
    {
        #region Injects

        [Inject]
        private IMerchantService MerchantService { get; set; }

        [Inject]
        private IMerchantServeService MerchantServeService { get; set; }

        [Inject]
        private ILocationService LocationService { get; set; }

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
            EditContext = new(Model);
        }

        private void OnSave()
        {
            try
            {
                if (Model.IsNew)
                {
                    Merchant merchant = MerchantService
                        .Create(Model.Name, Model.Description, Model.MerchantType);

                    MerchantServe merchantServe = MerchantServeService
                        .Create(merchant.Id, Model.Name, Model.Description, MerchantServeType.Restaurant);

                    Location location = LocationService
                        .Create(merchantServe.Id, Resources.DefaultLocationName);

                    Navigator.NavigateTo($"/admin/merchant/{merchant.Id}");
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
            Navigator.NavigateTo("/admin/merchant/list");
        }

        #endregion Methods

        #region Properties

        private EditContext EditContext { get; set; }

        #endregion Properties
    }
}
