namespace Azox.Infrastructure.Core
{
    using Azox.Business.Core.Data;
    using Azox.Business.Core.Domain;
    using Azox.Business.Core.Service;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// 
    /// </summary>
    public abstract class EntityServiceBase<TEntity> :
        IEntityService<TEntity>
        where TEntity : class, IEntity
    {
        #region Fields

        private IRepository<TEntity> _repository;

        #endregion Fields

        #region Ctor

        protected EntityServiceBase(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        #endregion Ctor

        #region Properties

        protected IRepository<TEntity> Repository => 
            _repository = ServiceProvider.GetRequiredService<IRepository<TEntity>>();

        protected IServiceProvider ServiceProvider { get; }

        #endregion Properties
    }
}
