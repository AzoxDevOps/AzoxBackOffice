namespace Azox.Business.Core.Service
{
    using Azox.Business.Core.Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// 
    /// </summary>
    public partial interface IEntityService<TEntity>
    {
        /// <summary>
        /// 
        /// </summary>
        Task<IEnumerable<TDto>> FilterAsync<TDto>(Expression<Func<TEntity, bool>> predicate)
            where TDto : IDtoFor<TEntity>;

        /// <summary>
        /// 
        /// </summary>
        Task<TDto> FirstOrDefaultAsync<TDto>(Expression<Func<TEntity, bool>> predicate)
            where TDto : IDtoFor<TEntity>;

        /// <summary>
        /// 
        /// </summary>
        Task<IEnumerable<TDto>> GetAllAsync<TDto>()
            where TDto : IDtoFor<TEntity>;

        /// <summary>
        /// 
        /// </summary>
        Task<TDto> GetByIdAsync<TDto>(Guid id)
            where TDto : IDtoFor<TEntity>;

        /// <summary>
        /// 
        /// </summary>
        Task<TDto> GetByIdAsync<TDto>(int id)
            where TDto : IDtoFor<TEntity>;

        /// <summary>
        /// 
        /// </summary>
        Task<TDto> GetByIdAsync<TDto>(long id)
            where TDto : IDtoFor<TEntity>;

        /// <summary>
        /// 
        /// </summary>
        Task<TDto> SingleOrDefaultAsync<TDto>(Expression<Func<TEntity, bool>> predicate)
            where TDto : IDtoFor<TEntity>;
    }
}
