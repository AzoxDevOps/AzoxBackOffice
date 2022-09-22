namespace Azox.XQR.Presentation.Areas.Admin.Pages
{
    using Azox.Toolkit.Blazor.Services;
    using Azox.XQR.Presentation.Areas.Admin.Models;
    using Azox.XQR.Presentation.Areas.Admin.Services;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;

    public partial class Login
    {
        #region Injects

        [Inject]
        ILocalStorageService LocalStorageService { get; set; }

        [Inject]
        IAuthStateProvider AuthStateProvider { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        #endregion Injects

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await LocalStorageService.GetItemAsStringAsync("temp");
                ShowLogin = true;
            }
            catch
            {
                ShowLogin = false;
            }
        }

        private async Task OnValidSubmit()
        {
            IsBusy = true;
            var result = await AuthStateProvider.LoginAsync(Model);

            if (result.Success)
            {
                NavigationManager.NavigateTo("/admin", true);
            }
            else
            {
                IsBusy = false;
                ResponseMessage = result.ToString();
            }
        }

        #endregion Methods

        #region Properties

        private bool ShowLogin { get; set; }

        private bool IsBusy { get; set; }

        private string? ResponseMessage { get; set; }

        private LoginModel Model { get; set; } = new();

        #endregion Properties
    }
}
