namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Product
{
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Business;
    using Microsoft.AspNetCore.Components;

    public partial class ProductEdit
    {
        #region Injects

        [Inject]
        private IProductService ProductService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        #endregion

        #region Parameters

        [Parameter]
        public int ProductId { get; set; }

        #endregion Parameters

        #region Methods

        protected override void OnParametersSet()
        {
            base.OnInitialized();

            Model = ProductService.GetById<ProductDto>(ProductId);
            bool allowEdit = UserServices.Contains(Model.Category.Service.Id) || UserGroupType == UserGroupType.Admin;

            if (!allowEdit || Model.IsDeleted)
            {
                Navigator.NavigateTo("/admin/product/list");
            }
        }

        #endregion Methods

        #region Properties

        public ProductDto Model { get; set; }

        #endregion Properties
    }
}
