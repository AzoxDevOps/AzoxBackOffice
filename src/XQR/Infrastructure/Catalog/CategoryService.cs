namespace Azox.XQR.Infrastructure
{
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;

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
    }
}
