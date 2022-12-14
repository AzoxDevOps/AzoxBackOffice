namespace Azox.Persistence.Core
{
    using Azox.Business.Core;
    using Azox.Business.Core.Data;
    using Azox.Business.Core.Domain;
    using Azox.Core;

    using Microsoft.EntityFrameworkCore;

    using System.Linq.Expressions;

    /// <summary>
    /// 
    /// </summary>
    internal partial class GenericRepository<TEntity> :
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

        /// <summary>
        /// 
        /// </summary>
        public virtual bool Any(Expression<Func<TEntity, bool>> predicate) =>
             Entities.Any(predicate);

        /// <summary>
        /// 
        /// </summary>
        public virtual int Count() =>
             Entities.Count();

        /// <summary>
        /// 
        /// </summary>
        public virtual int Count(Expression<Func<TEntity, bool>> predicate) =>
             Entities.Count(predicate);

        /// <summary>
        /// 
        /// </summary>
        public virtual TEntity FirstOrDefault() =>
             Entities.FirstOrDefault();

        /// <summary>
        /// 
        /// </summary>
        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate) =>
             Entities.FirstOrDefault(predicate);

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate) =>
             Entities.Where(predicate).ToList();

        public virtual IEnumerable<TEntity> Filter(
            Expression<Func<TEntity, bool>> predicate,
            params SortProvider<TEntity>[] sortProviders)
        {
            IQueryable<TEntity> query = Entities.Where(predicate);

            if (sortProviders != null)
            {
                IOrderedQueryable<TEntity> orderQuery = sortProviders[0].SortOrder switch
                {
                    SortOrder.Ascending => query.OrderBy(sortProviders[0].Predicate),
                    SortOrder.Descending => query.OrderByDescending(sortProviders[0].Predicate),
                    _ => throw new AzoxBugException()
                };

                if (sortProviders.Length > 1)
                {
                    for (int i = 1; i < sortProviders.Length; i++)
                    {
                        orderQuery = sortProviders[i].SortOrder switch
                        {
                            SortOrder.Ascending => orderQuery.ThenBy(sortProviders[i].Predicate),
                            SortOrder.Descending => orderQuery.ThenByDescending(sortProviders[i].Predicate),
                            _ => throw new AzoxBugException()
                        };
                    }
                }

                return orderQuery.ToList();
            }

            return query.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<TEntity> GetAll() =>
             Entities.ToList();

        /// <summary>
        /// 
        /// </summary>
        public virtual TEntity GetById(Guid id) =>
             Entities.Find(id);

        /// <summary>
        /// 
        /// </summary>
        public virtual TEntity GetById(int id) =>
             Entities.Find(id);

        /// <summary>
        /// 
        /// </summary>
        public virtual TEntity GetById(long id) =>
             Entities.Find(id);

        /// <summary>
        /// 
        /// </summary>
        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate) =>
             Entities.SingleOrDefault(predicate);

        public virtual void Insert(TEntity entity) =>
            Entities.Add(entity);

        public virtual void InsertRange(IEnumerable<TEntity> entities) =>
            Entities.AddRange(entities);

        public virtual void Update(TEntity entity) =>
            Entities.Update(entity);

        public virtual void UpdateRange(IEnumerable<TEntity> entities) =>
            Entities.UpdateRange(entities);

        public virtual void Delete(TEntity entity)
        {
            if (typeof(IDeletableEntity).IsAssignableFrom(typeof(TEntity)))
            {
                IDeletableEntity deletableEntity = (IDeletableEntity)entity;
                deletableEntity.IsDeleted = true;
                deletableEntity.DeletionTime = DateTime.Now;

                Update(entity);
                return;
            }

            Entities.Remove(entity);
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Delete(entity);
            }
        }

        public virtual int SaveChanges()
        {
            try
            {
                int saveChangesResult = _dbContext.SaveChanges();

                return saveChangesResult;
            }
            catch
            {
                throw;
            }
        }

        #endregion Methods

        #region Properties

        public DbSet<TEntity> Entities => _entities = _dbContext.Set<TEntity>();

        #endregion Properties
    }
}
