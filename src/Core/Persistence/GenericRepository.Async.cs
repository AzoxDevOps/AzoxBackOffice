namespace Azox.Persistence.Core
{
    using Azox.Business.Core.Data;
    using Azox.Core;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    internal partial class GenericRepository<TEntity>
    {
        #region Methods

        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate) =>
            await Entities.AnyAsync(predicate);

        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<int> CountAsync() =>
            await Entities.CountAsync();

        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate) =>
            await Entities.CountAsync(predicate);

        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<TEntity> FirstOrDefaultAsync() =>
            await Entities.FirstOrDefaultAsync();

        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) =>
            await Entities.FirstOrDefaultAsync(predicate);

        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> predicate) =>
            await Entities.Where(predicate).ToListAsync();

        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<IEnumerable<TEntity>> FilterAsync(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> sort,
            SortOrder sortOrder = SortOrder.Ascending)
        {
            IQueryable<TEntity> query = Entities.Where(predicate);

            query = sortOrder switch
            {
                SortOrder.Ascending => query.OrderBy(sort),
                SortOrder.Descending => query.OrderByDescending(sort),
                _ => throw new AzoxBugException()
            };

            return await query.ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() =>
            await Entities.ToListAsync();

        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<TEntity> GetByIdAsync(Guid id) =>
            await Entities.FindAsync(id);

        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<TEntity> GetByIdAsync(int id) =>
            await Entities.FindAsync(id);

        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<TEntity> GetByIdAsync(long id) =>
            await Entities.FindAsync(id);

        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) =>
            await Entities.SingleOrDefaultAsync(predicate);

        public virtual async Task InsertAsync(TEntity entity) =>
            await Entities.AddAsync(entity);

        public virtual async Task InsertRangeAsync(IEnumerable<TEntity> entities) =>
            await Entities.AddRangeAsync(entities);

        public virtual async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _dbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        #endregion Methods
    }
}
