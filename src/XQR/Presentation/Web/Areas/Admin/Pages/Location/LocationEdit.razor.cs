namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Location
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;

    using Microsoft.AspNetCore.Components;

    using System.Threading.Tasks;

    public partial class LocationEdit
    {
        #region Injects

        [Inject]
        private ILocationService LocationService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        #endregion

        #region Parameters

        [Parameter]
        public int LocationId { get; set; }

        #endregion Parameters

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Model = LocationService.GetById<LocationDto>(LocationId);

            bool allowEdit = UserServices.Contains(Model.Service.Id) || UserGroupType == UserGroupType.Admin;

            if (!allowEdit || Model.IsDeleted)
            {
                Navigator.NavigateTo("/admin/location/list");
            }

            Model.OnPropertyChanged = () =>
            {
                Model = LocationService.GetById<LocationDto>(LocationId);
                StateHasChanged();
            };
        }

        #endregion Methods

        #region Properties

        public LocationDto Model { get; set; }

        #endregion Properties
    }
}
