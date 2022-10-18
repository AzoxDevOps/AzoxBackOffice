namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Location
{
    using Azox.Toolkit.Blazor;
    using Azox.Toolkit.Blazor.Helpers;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Core.Localization;

    using Microsoft.AspNetCore.Components;

    public partial class LocationDetail
    {
        #region Injects

        [Inject]
        private IJsRuntimeHelper JsRuntimeHelper { get; set; }

        [Inject]
        private ILocationService LocationService { get; set; }

        [Inject]
        private ILogger<LocationDetail> Logger { get; set; }

        [Inject]
        private IToastService ToastService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        #endregion Injects

        #region Parameters

        [CascadingParameter]
        public LocationDto Model { get; set; }

        #endregion Parameters

        #region Methods

        private void OnSave(bool saveAndClose)
        {
            try
            {
                if (Model.IsNew)
                {
                    Location location = LocationService
                        .Create(Model.Service.Id, Model.Name);

                    Model.Id = location.Id;
                }
                else
                {
                    Location location = LocationService.GetById(Model.Id);

                    location.Name = Model.Name;
                    location.Description = Model.Description;
                    location.IsActive = Model.IsActive;

                    LocationService.Update(location);
                }

                if (!saveAndClose)
                {
                    Navigator.NavigateTo($"/admin/location/{Model.Id}");
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
            bool confirm = await JsRuntimeHelper.GetConfirmResult(Resources.DeleteConfirm);
            if (confirm)
            {
                await Task.Run(() => LocationService.Delete(Model.Id));
                await OnClose();
            }
        }

        private async Task OnClose()
        {
            await Task.Run(() => Navigator.NavigateTo("/admin/location/list"));
        }

        #endregion Methods
    }
}
