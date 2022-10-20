namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Location
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;

    public partial class LocationCreate
    {
        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Model = new();

            if (UserGroupType != Business.UserGroupType.Admin)
            {
                if (UserServices.Count() == 1)
                {
                    Model.Service.Id = UserServices.FirstOrDefault();
                }
            }
        }

        #endregion Methods

        #region Properties

        public LocationDto Model { get; set; }

        #endregion Properties
    }
}
