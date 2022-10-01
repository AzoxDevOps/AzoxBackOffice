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
        public virtual IEnumerable<TDto> Filter<TDto>(Expression<Func<TEntity, bool>> predicate)
            where TDto : IDtoFor<TEntity> => Filter(predicate).ToDto<TEntity, TDto>();

        /// <summary>
        /// 
        /// </summary>
        public virtual TDto FirstOrDefault<TDto>(Expression<Func<TEntity, bool>> predicate)
            where TDto : IDtoFor<TEntity> => FirstOrDefault(predicate).ToDto<TEntity, TDto>();

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<TDto> GetAll<TDto>()
            where TDto : IDtoFor<TEntity> => GetAll().ToDto<TEntity, TDto>();

        /// <summary>
        /// 
        /// </summary>
        public virtual TDto GetById<TDto>(Guid id)
            where TDto : IDtoFor<TEntity> => GetById(id).ToDto<TEntity, TDto>();

        /// <summary>
        /// 
        /// </summary>
        public virtual TDto GetById<TDto>(int id)
            where TDto : IDtoFor<TEntity> => GetById(id).ToDto<TEntity, TDto>();

        /// <summary>
        /// 
        /// </summary>
        public virtual TDto GetById<TDto>(long id)
            where TDto : IDtoFor<TEntity> => GetById(id).ToDto<TEntity, TDto>();

        /// <summary>
        /// 
        /// </summary>
        public virtual TDto SingleOrDefault<TDto>(Expression<Func<TEntity, bool>> predicate)
            where TDto : IDtoFor<TEntity> => SingleOrDefault(predicate).ToDto<TEntity, TDto>();

        #endregion Methods
    }
}
