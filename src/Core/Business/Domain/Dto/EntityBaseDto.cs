namespace Azox.Business.Core.Domain.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class EntityBaseDto<TEntity, TId>
        where TEntity : EntityBase<TId>
        where TId : struct
    {
        #region Ctor

        protected EntityBaseDto() { }

        protected EntityBaseDto(TEntity entity)
        {
            Id = entity.Id;
        }

        #endregion Ctor

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public TId Id { get; }

        #endregion Properties
    }
}