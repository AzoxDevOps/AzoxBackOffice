namespace Azox.XQR.Infrastructure
{
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;

    using Microsoft.Extensions.DependencyInjection;

    internal class CategoryService :
        EntityServiceBase<Category, CategoryService>,
        ICategoryService
    {
        #region Ctor

        public CategoryService(IServiceProvider serviceProvider) :
            base(serviceProvider)
        {

        }

        #endregion Ctor

        #region Methods

        public virtual Category Create(int merchantServeId, string name, string description)
        {
            IMerchantServeService merchantServeService = ServiceProvider
                .GetRequiredService<IMerchantServeService>();

            MerchantServe merchantServe = merchantServeService
                .GetById(merchantServeId);

            int lastDisplayOrder = Count(x => x.Service.Id == merchantServeId);

            Category category = new()
            {
                Service = merchantServe,
                Name = name,
                Description = description,
                IsActive = true,
                DisplayOrder = lastDisplayOrder++
            };

            Insert(category);
            return GetById(category.Id);
        }

        #endregion Methods
    }
}
