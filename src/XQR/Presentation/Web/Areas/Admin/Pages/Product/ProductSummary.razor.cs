namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Product
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Web.Areas.Admin.Components;

    using Microsoft.AspNetCore.Components;

    public partial class ProductSummary :
        Summary<ProductDto>
    {
        #region Injects

        [Inject]
        private IProductService ProductService { get; set; }

        #endregion Injects

        #region Methods

        protected override void InitializeDataSource(UserGroupType userGroupType, int merchantId, int serviceId)
        {
            if (userGroupType == UserGroupType.Admin)
            {
                DataSource = ProductService.Filter<ProductDto>(x => !x.IsDeleted);
            }
            else if (userGroupType == UserGroupType.MerchantAdmin)
            {
                DataSource = ProductService.Filter<ProductDto>(x => !x.IsDeleted && x.Category.Service.Merchant.Id == merchantId);
            }
            else
            {
                DataSource = ProductService.Filter<ProductDto>(x => !x.IsDeleted && x.Category.Service.Id == serviceId);
            }
        }

        protected override void OnDelete(int id)
        {

        }

        #endregion Methods

        #region Properties

        protected override string DetailUrl => "product";

        #endregion Properties
    }
}
