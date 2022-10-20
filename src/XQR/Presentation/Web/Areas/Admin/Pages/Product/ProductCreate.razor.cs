namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Product
{
    using Azox.XQR.Business.Dto;

    public partial class ProductCreate
    {
        #region Methods

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Model = new();
        }

        #endregion Methods

        #region Properties

        public ProductDto Model { get; set; }

        #endregion Properties
    }
}
