﻿namespace Azox.Business.Core.Service
{
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public partial interface IEntityService<TEntity>
    {
        #region Methods

        /// <summary>
        /// 
        /// </summary>
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// 
        /// </summary>
        Task<TEntity> GetByIdAsync(Guid id);

        /// <summary>
        /// 
        /// </summary>
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        Task<TEntity> GetByIdAsync(long id);

        /// <summary>
        /// 
        /// </summary>
        Task InsertAsync(TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion Methods
    }
}