namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Category
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;

    using Microsoft.AspNetCore.Authorization;

    [Authorize(Roles = $"{nameof(UserGroupType.Admin)}, {nameof(UserGroupType.MerchantAdmin)}, {nameof(UserGroupType.ServiceAdmin)}")]
    public partial class CategoryCreate
    {
        #region Methods

        protected override void OnInitialized()
        {
            Model = new()
            {
                Parent = new()
            };
        }

        #endregion Methods

        #region Properties

        private CategoryDto Model { get; set; }

        #endregion Properties
    }
}
