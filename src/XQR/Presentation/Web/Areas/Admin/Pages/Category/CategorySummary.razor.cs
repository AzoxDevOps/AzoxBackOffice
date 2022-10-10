namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Category
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Web.Areas.Admin.Components;

    using Microsoft.AspNetCore.Components;

    public partial class CategorySummary :
        Summary<CategoryDto>
    {
        #region Injects

        [Inject]
        private ICategoryService CategoryService { get; set; }

        #endregion Injects

        #region Methods

        protected override void InitializeDataSource(UserGroupType userGroupType, int merchantId,int serviceId)
        {
            if (userGroupType == UserGroupType.Admin)
            {
                DataSource = CategoryService.Filter<CategoryDto>(x => !x.IsDeleted);
            }
            else if (userGroupType == UserGroupType.MerchantAdmin)
            {
                DataSource = CategoryService.Filter<CategoryDto>(x => !x.IsDeleted && x.Service.Merchant.Id == merchantId);
            }
            else
            {
                DataSource = CategoryService.Filter<CategoryDto>(x => !x.IsDeleted && x.Service.Id == serviceId);
            }
        }

        protected override void OnDelete(int id)
        {

        }

        #endregion Methods

        #region Properties

        protected override string DetailUrl => "category";

        #endregion Properties
    }
}

