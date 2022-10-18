namespace Azox.Business.Core.Data
{
    using Azox.Business.Core.Domain;

    using System.Linq.Expressions;

    /// <summary>
    /// 
    /// </summary>
    public partial interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        bool Any(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        int Count();

        /// <summary>
        /// 
        /// </summary>
        int Count(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        TEntity FirstOrDefault();

        /// <summary>
        /// 
        /// </summary>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<TEntity> Filter(
            Expression<Func<TEntity, bool>> predicate,
            params SortProvider<TEntity>[] sortProviders);

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// 
        /// </summary>
        TEntity GetById(Guid id);

        /// <summary>
        /// 
        /// </summary>
        TEntity GetById(int id);

        /// <summary>
        /// 
        /// </summary>
        TEntity GetById(long id);

        /// <summary>
        /// 
        /// </summary>
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        void Insert(TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        void InsertRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// 
        /// </summary>
        void Update(TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        void UpdateRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// 
        /// </summary>
        void Delete(TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        void DeleteRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// 
        /// </summary>
        int SaveChanges();
    }
}
