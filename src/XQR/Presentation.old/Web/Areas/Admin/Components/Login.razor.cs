namespace Azox.XQR.Presentation.Web.Areas.Admin.Components
{
    using Azox.Toolkit.Blazor;
    using Azox.XQR.Business;
    using Azox.XQR.Presentation.Core.Localization;
    using Azox.XQR.Presentation.Web.Areas.Admin.Services;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

    public partial class Login
    {
        #region Fields

        private bool _isBusy;
        private bool _passwordChangeOnFirstLogin;
        private bool _show;

        private string _username;
        private string _password;
        private string _newPassword;
        private string _newPasswordCheck;

        #endregion Fields

        #region Injects

        [Inject]
        private IUserService UserService { get; set; }

        [Inject]
        private ProtectedLocalStorage LocalStorageService { get; set; }

        [Inject]
        private IToastService ToastService { get; set; }

        [Inject]
        AuthenticationStateProvider AuthStateProvider { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        #endregion Injects

        #region Utils

        private void PasswordChangeOnFirstLoginCheck()
        {
            if (!_passwordChangeOnFirstLogin)
            {
                return;
            }

            if (_newPassword != _newPasswordCheck)
            {
                ToastService.Show(new ToastMessage
                {
                    Type = ToastType.Warning,
                    Message = Resources.UnmatchedPassword
                });
                _isBusy = false;
                return;
            }
            else
            {
                if (UserService.UpdatePassword(_username, _newPassword))
                {
                    _password = _newPassword;
                    return;
                }

                ToastService.Show(new ToastMessage
                {
                    Type = ToastType.Warning,
                    Message = Resources.GeneralErrorMessage
                });
                _isBusy = false;
                return;
            }
        }

        #endregion Utils

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await LocalStorageService.GetAsync<string>("temp");
                _show = true;
            }
            catch
            {
                _show = false;
            }
        }

        private async Task SignIn()
        {
            _isBusy = true;

            PasswordChangeOnFirstLoginCheck();

            ValidateCredentialsResult result = await ((IAuthService)AuthStateProvider)
                .SignIn(_username, _password);

            if (result == ValidateCredentialsResult.Succeeded)
            {
                NavigationManager.NavigateTo("/admin", true);
            }
            else
            {
                if (result == ValidateCredentialsResult.PasswordChangeOnFirstLogin)
                {
                    _passwordChangeOnFirstLogin = true;
                }
                else if (result == ValidateCredentialsResult.InactiveUser)
                {
                    ToastService.Show(new ToastMessage
                    {
                        Type = ToastType.Warning,
                        Message = Resources.InactiveUser
                    });
                }
                else if (result == ValidateCredentialsResult.InvalidUsernameOrPassword)
                {
                    ToastService.Show(new ToastMessage
                    {
                        Type = ToastType.Warning,
                        Message = Resources.InvalidUsernameOrPassword
                    });
                }
                else if (result == ValidateCredentialsResult.LockedUser)
                {
                    ToastService.Show(new ToastMessage
                    {
                        Type = ToastType.Warning,
                        Message = Resources.LockedUser
                    });
                }
            }

            _isBusy = false;
        }

        #endregion Methods
    }
}
