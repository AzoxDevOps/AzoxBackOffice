namespace Azox.Business.Core.Service
{
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
        void Insert(TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        void Update(TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        void Delete(TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        #endregion Methods
    }
}
