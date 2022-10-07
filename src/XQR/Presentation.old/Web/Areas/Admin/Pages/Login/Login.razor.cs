namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Login
{
    using Azox.Toolkit.Blazor;
    using Azox.XQR.Business;
    using Azox.XQR.Presentation.Web.Core.Services;

    using Microsoft.AspNetCore.Components;

    using System.Threading.Tasks;

    public partial class Login
    {
        #region Injects

        [Inject]
        private ILocalStorageService LocalStorageService { get; set; }

        [Inject]
        private IToastService ToastService { get; set; }

        [Inject]
        private ILoginService LoginService { get; set; }

        [Inject]
        private IServiceScopeFactory ServiceScopeFactory { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        #endregion Injects

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await LocalStorageService.GetItemAsStringAsync("temp");
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

            if (NewPassword != NewPasswordConfirm)
            {
                ToastService.Show(new ToastMessage
                {
                    Type = ToastType.Error,
                    Message = "Girilen şifreler eşleşmedi"
                });
                IsBusy = false;
                return;
            }
            else
            {
                IUserService _userService = ServiceScopeFactory.CreateAsyncScope().ServiceProvider.GetRequiredService<IUserService>();

                if (await _userService.UpdatePassword(Username,NewPassword))
                {
                    Password = NewPassword;
                }
                else
                {
                    ToastService.Show(new ToastMessage
                    {
                        Type = ToastType.Error,
                        Message = "Sistemde bir hata oluştu"
                    });
                    IsBusy = false;
                    return;
                }
            }
        }

        private async Task LoginAsync()
        {
            IsBusy = true;

            await PasswordChangeOnFirstLoginCheck();

            ValidateCredentialsResult result = await LoginService.LoginAsync(Username, Password);

            if (result == ValidateCredentialsResult.Succeeded)
            {
                NavigationManager.NavigateTo("/admin", true);
            }
            else
            {
                if (result == ValidateCredentialsResult.PasswordChangeOnFirstLogin)
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

        private string Username { get; set; }
        private string Password { get; set; }
        private string NewPassword { get; set; }
        private string NewPasswordConfirm { get; set; }

        #endregion Properties
    }
}
