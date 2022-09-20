namespace Azox.XQR.Presentation.Areas.Admin.Pages
{
    using Azox.XQR.Presentation.Areas.Admin.Models;
    using Azox.XQR.Presentation.Areas.Admin.Services;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;

    public partial class Login
    {
        #region Fields

        private bool _isBusy;

        #endregion Fields

        #region Methods

        protected override void OnInitialized()
        {
            Model = new();
        }

        private async Task OnValidSubmit()
        {
            _isBusy = true;
            var result = await AuthStateProvider.LoginAsync(Model);

            if (result.Success)
            {
                _isBusy = false;
                NavigationManager.NavigateTo("/admin", true);
            }
        }

        private async Task OnInvalidSubmit(EditContext editContext)
        {
            await Task.CompletedTask;
        }

        #endregion Methods

        #region Properties

        private LoginModel Model { get; set; }

        [Inject]
        IAuthStateProvider AuthStateProvider { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        #endregion Properties
    }
}
