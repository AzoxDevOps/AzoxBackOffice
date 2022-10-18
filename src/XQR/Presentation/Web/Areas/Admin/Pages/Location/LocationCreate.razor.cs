namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Location
{
    using Azox.XQR.Business.Dto;

    public partial class LocationCreate
    {
        #region Methods

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Model = new();
        }

        #endregion Methods

        #region Properties

        public LocationDto Model { get; set; }

        #endregion Properties
    }
}
