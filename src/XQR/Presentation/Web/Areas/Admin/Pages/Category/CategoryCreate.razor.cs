namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Category
{
    using Azox.XQR.Business.Dto;

    public partial class CategoryCreate
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

        public CategoryDto Model { get; set; }

        #endregion Properties
    }
}
