namespace Azox.Infrastructure.Core
{
    using Azox.Business.Core.Dto;
    using Azox.Business.Core.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public abstract partial class EntityServiceBase<TEntity, TService>
    {
        #region Methods

        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<IEnumerable<TDto>> FilterAsync<TDto>(Expression<Func<TEntity, bool>> predicate)
            where TDto : IDtoFor<TEntity> => (await FilterAsync(predicate)).ToDto<TEntity, TDto>();

        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<TDto> FirstOrDefaultAsync<TDto>(Expression<Func<TEntity, bool>> predicate)
            where TDto : IDtoFor<TEntity> => (await FirstOrDefaultAsync(predicate)).ToDto<TEntity, TDto>();

        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<IEnumerable<TDto>> GetAllAsync<TDto>()
            where TDto : IDtoFor<TEntity> => (await GetAllAsync()).ToDto<TEntity, TDto>();

        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<TDto> GetByIdAsync<TDto>(Guid id)
            where TDto : IDtoFor<TEntity> => (await GetByIdAsync(id)).ToDto<TEntity, TDto>();

        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<TDto> GetByIdAsync<TDto>(int id)
            where TDto : IDtoFor<TEntity> => (await GetByIdAsync(id)).ToDto<TEntity, TDto>();

        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<TDto> GetByIdAsync<TDto>(long id)
            where TDto : IDtoFor<TEntity> => (await GetByIdAsync(id)).ToDto<TEntity, TDto>();

        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<TDto> SingleOrDefaultAsync<TDto>(Expression<Func<TEntity, bool>> predicate)
            where TDto : IDtoFor<TEntity> => (await SingleOrDefaultAsync(predicate)).ToDto<TEntity, TDto>();

        #endregion Methods
    }
}
