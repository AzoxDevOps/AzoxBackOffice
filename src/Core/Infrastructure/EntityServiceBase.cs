namespace Azox.Infrastructure.Core
{
    using Azox.Business.Core.Data;
    using Azox.Business.Core.Domain;
    using Azox.Business.Core.Service;

    /// <summary>
    /// 
    /// </summary>
    public abstract class EntityServiceBase<TEntity> :
        IEntityService<TEntity>
        where TEntity : class, IEntity
    {
        #region Ctor

        protected EntityServiceBase(IRepository<TEntity> repository)
        {
            Repository = repository;
        }

        #endregion Ctor

        #region Properties

        protected IRepository<TEntity> Repository { get; }

        #endregion Properties
    }
}
