namespace Azox.Business.Core.Service
{
    using Azox.Business.Core.Data;
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
        IEnumerable<TDto> Filter<TDto>(Expression<Func<TEntity, bool>> predicate)
            where TDto : IDtoFor<TEntity>;

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<TDto> Filter<TDto>(
            Expression<Func<TEntity, bool>> predicate,
            params SortProvider<TEntity>[] sortProviders)
            where TDto : IDtoFor<TEntity>;

        /// <summary>
        /// 
        /// </summary>
        TDto FirstOrDefault<TDto>(Expression<Func<TEntity, bool>> predicate)
            where TDto : IDtoFor<TEntity>;

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<TDto> GetAll<TDto>()
            where TDto : IDtoFor<TEntity>;

        /// <summary>
        /// 
        /// </summary>
        TDto GetById<TDto>(Guid id)
            where TDto : IDtoFor<TEntity>;

        /// <summary>
        /// 
        /// </summary>
        TDto GetById<TDto>(int id)
            where TDto : IDtoFor<TEntity>;

        /// <summary>
        /// 
        /// </summary>
        TDto GetById<TDto>(long id)
            where TDto : IDtoFor<TEntity>;

        /// <summary>
        /// 
        /// </summary>
        TDto SingleOrDefault<TDto>(Expression<Func<TEntity, bool>> predicate)
            where TDto : IDtoFor<TEntity>;
    }
}
