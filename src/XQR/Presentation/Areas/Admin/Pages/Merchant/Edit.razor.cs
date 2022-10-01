namespace Azox.XQR.Presentation.Areas.Admin.Pages.Merchant
{
    using Azox.Toolkit.Blazor;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Microsoft.AspNetCore.Components;

    public partial class Edit
    {
        #region Injects

        [Inject]
        private IMerchantService MerchantService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        IToastService ToastService { get; set; }

        #endregion Injects

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Model = await MerchantService.GetByIdAsync<MerchantDto>(Id);
        }

        private async Task SaveAsync()
        {
            Merchant merchant = await MerchantService.GetByIdAsync(Id);

            merchant.Name = Model.Name;
            merchant.Description = Model.Description;
            merchant.Contact = Model.Contact;

            MerchantService.Update(merchant);
            ToastService.Show(new ToastMessage
            {
                Type = ToastType.Success,
                Message = "Kayıt işlemi tamamlandı"
            });
        }

        private async Task SaveAndCloseAsync()
        {
            await SaveAsync();
            NavigationManager.NavigateTo("/admin/merchant");
        }

        private async Task DeleteAsync()
        {
            await Task.CompletedTask;
        }

        #endregion Methods

        #region Parameters

        [Parameter]
        public int Id { get; set; }

        #endregion Parameter

        #region Properties

        private MerchantDto Model { get; set; }

        #endregion Properties
    }
}
