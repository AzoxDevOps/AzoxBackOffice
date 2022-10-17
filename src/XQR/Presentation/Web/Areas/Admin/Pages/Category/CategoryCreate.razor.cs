namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Category
{
    using Azox.XQR.Business.Dto;

    public partial class CategoryCreate
    {
        #region Methods

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Model = new();
        }

        #endregion Methods

        #region Properties

        public CategoryDto Model { get; set; }

        #endregion Properties
    }
}
