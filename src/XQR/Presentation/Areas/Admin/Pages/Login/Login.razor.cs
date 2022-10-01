namespace Azox.XQR.Presentation.Areas.Admin.Pages.Login
{
    using Azox.Toolkit.Blazor;
    using Azox.XQR.Business;
    using Azox.XQR.Presentation.Core.Services;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;
    using System.Threading.Tasks;

    public partial class Login
    {
        #region Injects

        [Inject]
        private ILocalStorageService LocalStorageService { get; set; }

        [Inject]
        private ILoginService AuthStateProvider { get; set; }

        [Inject]
        private IToastService ToastService { get; set; }

        [Inject]
        private IUserService UserService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        #endregion Injects

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            try
            {
                await LocalStorageService.GetItemAsStringAsync("temp");
                Model = new();
                Show = true;
            }
            catch
            {
                Show = false;
            }
        }

        private async Task PasswordChangeOnFirstLoginCheck()
        {
            if (!PasswordChangeOnFirstLogin)
            {
                return;
            }

            if (Model.NewPassword != Model.ConfirmNewPassword)
            {
                ToastService.Show(new ToastMessage { Type = ToastType.Error, Message = "Girilen şifreler eşleşmedi" });
                IsBusy = false;
                return;
            }
            else
            {
                if (await UserService.UpdatePassword(Model.Username, Model.NewPassword))
                {
                    Model.Password = Model.NewPassword;
                }
                else
                {
                    ToastService.Show(new ToastMessage { Type = ToastType.Error, Message = "Sistemde bir hata oluştu." });
                    IsBusy = false;
                    return;
                }
            }
        }

        private async Task LoginAsync(EditContext context)
        {
            IsBusy = true;

            await PasswordChangeOnFirstLoginCheck();

            var result = await AuthStateProvider.LoginAsync(Model.Username, Model.Password);

            if (result == Business.ValidateCredentialsResult.Succeeded)
            {
                NavigationManager.NavigateTo("/admin", true);
            }
            else
            {
                if (result == Business.ValidateCredentialsResult.PasswordChangeOnFirstLogin)
                {
                    PasswordChangeOnFirstLogin = true;
                }
            }

            IsBusy = false;
        }

        #endregion Methods

        #region Properties

        private bool IsBusy { get; set; }

        private bool PasswordChangeOnFirstLogin { get; set; }

        private bool Show { get; set; }

        private LoginModel Model { get; set; }

        #endregion Properties
    }
}
