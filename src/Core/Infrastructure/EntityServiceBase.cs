namespace Azox.Infrastructure.Core
{
    using Azox.Business.Core.Data;
    using Azox.Business.Core.Domain;
    using Azox.Business.Core.Service;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System.Linq.Expressions;

    /// <summary>
    /// 
    /// </summary>
    public abstract class EntityServiceBase<TEntity, TService> :
        IEntityService<TEntity>
        where TEntity : class, IEntity
        where TService : class, IEntityService<TEntity>
    {
        #region Fields

        private ILogger _logger;
        private IRepository<TEntity> _repository;

        #endregion Fields

        #region Ctor

        protected EntityServiceBase(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        #endregion Ctor

        #region Methods

        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate) =>
            Repository.SingleOrDefault(predicate);

        #endregion Methods

        #region Properties

        protected IRepository<TEntity> Repository =>
            _repository = ServiceProvider.GetRequiredService<IRepository<TEntity>>();

        protected ILogger Logger =>
            _logger = ServiceProvider.GetRequiredService<ILogger<TService>>();

        protected IServiceProvider ServiceProvider { get; }

        #endregion Properties
    }
}
