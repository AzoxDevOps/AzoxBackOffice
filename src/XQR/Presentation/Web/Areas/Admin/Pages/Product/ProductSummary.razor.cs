namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Product
{
    using Azox.Core.Extensions;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;

    using Microsoft.AspNetCore.Components;

    using System;
    using System.Linq.Expressions;

    public partial class ProductSummary
    {
        #region Injects

        [Inject]
        private IProductService ProductService { get; set; }

        #endregion Injects

        #region Methods

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (!firstRender)
            {
                if (AuthorizedServiceIds.Any())
                {
                    DataSource = ProductService.Filter<ProductDto>(x => !x.IsDeleted && AuthorizedServiceIds.Contains(x.Category.Service.Id));
                }
                else
                {
                    DataSource = ProductService.Filter<ProductDto>(x => !x.IsDeleted);
                }
            }
        }

        private void OnSearch()
        {
            Expression<Func<Product, bool>> predicate = x => !x.IsDeleted;

            if (AuthorizedServiceIds.Any())
            {
                predicate = predicate.And(x => AuthorizedServiceIds.Contains(x.Category.Service.Id));
            }

            DataSource = ProductService.Filter<ProductDto>(predicate);
        }

        #endregion Methods

        #region Properties

        public IEnumerable<ProductDto> DataSource { get; set; }

        #endregion Properties
    }
}
