namespace Azox.Persistence.Core
{
    using Azox.Business.Core.Data;
    using Azox.Business.Core.Domain;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// 
    /// </summary>
    internal class GenericRepository<TEntity> :
        IRepository<TEntity>
        where TEntity : class, IEntity
    {
        #region Fields

        private readonly IDbContext _dbContext;
        private DbSet<TEntity> _entities;

        #endregion Fields

        #region Ctor

        public GenericRepository(IDbContext dbContext) =>
            _dbContext = dbContext;

        #endregion Ctor

        #region Methods

        public virtual TEntity GetById(Guid id)
        {
            return Entities.Find(id);
        }

        public virtual TEntity GetById(int id)
        {
            return Entities.Find(id);
        }

        #endregion Methods

        #region Properties

        public DbSet<TEntity> Entities => _entities = _dbContext.Set<TEntity>();

        #endregion Properties
    }
}
