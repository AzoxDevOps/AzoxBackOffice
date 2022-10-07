namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Merchant
{
    using Azox.XQR.Business.Dto;

    public partial class Create
    {
        #region Methods

        protected override void OnInitialized()
        {
            Model = new();
        }

        #endregion Methods

        #region Properties

        private MerchantDto Model { get; set; }

        #endregion Properties
    }
}
