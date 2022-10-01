namespace Azox.Infrastructure.Core
{
    using Microsoft.Extensions.Caching.Memory;
    using System.Linq.Expressions;

    /// <summary>
    /// 
    /// </summary>
    public abstract partial class EntityServiceBase<TEntity, TService>
    {
        #region Methods

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await MemoryCache.GetOrCreateAsync(GetCacheKey(predicate),
                async ce => await Repository.AnyAsync(predicate));
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await MemoryCache.GetOrCreateAsync(GetCacheKey(predicate),
                async ce => await Repository.CountAsync(predicate));
        }

        public virtual async Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await MemoryCache.GetOrCreateAsync(GetCacheKey(predicate),
                async ce => await Repository.FilterAsync(predicate));
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await MemoryCache.GetOrCreateAsync(GetCacheKey(predicate),
                async ce => await Repository.FirstOrDefaultAsync(predicate));
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await MemoryCache.GetOrCreateAsync(GetCacheKey(),
                async ce => await Repository.GetAllAsync());
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await MemoryCache.GetOrCreateAsync(GetCacheKeyById(id),
                async ce => await Repository.GetByIdAsync(id));
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await MemoryCache.GetOrCreateAsync(GetCacheKeyById(id),
                async ce => await Repository.GetByIdAsync(id));
        }

        public virtual async Task<TEntity> GetByIdAsync(long id)
        {
            return await MemoryCache.GetOrCreateAsync(GetCacheKeyById(id),
                async ce => await Repository.GetByIdAsync(id));
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            try
            {
                await Repository.InsertAsync(entity);
                await Repository.SaveChangesAsync();

                ClearCacheKeys();

                await EventHandlerService.HandleAsync<IEntityInsertedEventHandler<TEntity>, TEntity>(entity);
            }
            catch (Exception ex)
            {

            }
        }

        public virtual async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await MemoryCache.GetOrCreateAsync(GetCacheKey(predicate),
                async ce => await Repository.SingleOrDefaultAsync(predicate));
        }

        #endregion Methods
    }
}
