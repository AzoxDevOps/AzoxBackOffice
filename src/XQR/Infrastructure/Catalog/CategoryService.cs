namespace Azox.XQR.Infrastructure
{
    using Azox.Business.Core.Data;
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Domain.Catalog;

    internal class CategoryService :
        EntityServiceBase<Category>,
        ICategoryService
    {
        #region Ctor

        public CategoryService(IRepository<Category> repository) :
            base(repository)
        {

        }

        #endregion Ctor
    }
}
