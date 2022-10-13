namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.MerchantServe
{
    using Azox.XQR.Business.Dto;

    public partial class MerchantServeCreate
    {
        #region Methods

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Model = new();
        }

        #endregion Methods

        #region Properties

        public MerchantServeDto Model { get; set; }

        #endregion Properties
    }
}
