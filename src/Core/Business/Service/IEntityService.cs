namespace Azox.Business.Core.Service
{
    using Azox.Business.Core.Data;
    using Azox.Business.Core.Domain;
    using System.Linq.Expressions;

    /// <summary>
    /// 
    /// </summary>
    public interface IEntityService
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public partial interface IEntityService<TEntity> :
        IEntityService
        where TEntity : class, IEntity
    {
        #region Methods

        /// <summary>
        /// 
        /// </summary>
        bool Any(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        int Count(Expression<Func<TEntity, bool>> predicate);

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
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

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
        void Delete(Guid id);

        /// <summary>
        /// 
        /// </summary>
        void Delete(int id);

        /// <summary>
        /// 
        /// </summary>
        void Delete(long id);

        /// <summary>
        /// 
        /// </summary>
        void DeleteRange(IEnumerable<TEntity> entities);

        #endregion Methods
    }
}
