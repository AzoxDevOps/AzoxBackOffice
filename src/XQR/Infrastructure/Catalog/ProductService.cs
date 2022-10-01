namespace Azox.XQR.Infrastructure
{
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;

    internal class ProductService :
        EntityServiceBase<Product, ProductService>,
        IProductService
    {
        #region Ctor

        public ProductService(IServiceProvider serviceProvider) :
            base(serviceProvider)
        {
        }

        #endregion Ctor
    }
}
