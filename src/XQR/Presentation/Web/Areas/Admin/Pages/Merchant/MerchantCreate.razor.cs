namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Merchant
{
    using Azox.XQR.Business.Dto;

    public partial class MerchantCreate
    {
        #region Methods

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Model = new();
        }

        #endregion Methods

        #region Properties

        public MerchantDto Model { get; set; }

        #endregion Properties
    }
}
