namespace Azox.XQR.Infrastructure
{
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;

    using Microsoft.Extensions.DependencyInjection;

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

        #region Methods

        public virtual Product Create(int categoryId, string name, string description,Price price)
        {
            ICategoryService categoryService = ServiceProvider
                .GetRequiredService<ICategoryService>();

            Category category = categoryService.GetById(categoryId);
            if (category == null)
            {

            }

            int lastDisplayOrder = Count(x => x.Category.Id == categoryId);

            Product product = new Product
            {
                Category = category,
                Name = name,
                Description = description,
                IsActive = true,
                DisplayOrder = ++lastDisplayOrder,
                Price = price,
                OldPrice= price,
            };

            Insert(product);
            return GetById(product.Id);
        }

        #endregion Methods
    }
}
