namespace Azox.Business.Core.Domain.Dto
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public abstract class TrackableEntityBaseDto<TEntity, TId> :
        EntityBaseDto<TEntity, TId>
        where TEntity : TrackableEntityBase<TId>
        where TId : struct
    {
        #region Ctor

        protected TrackableEntityBaseDto() :
            base()
        {
            CreationTime = DateTime.Now;
        }

        protected TrackableEntityBaseDto(TEntity entity) :
            base(entity)
        {
            CreationTime = entity.CreationTime;
        }

        #endregion Ctor

        #region Properties

        public DateTime CreationTime { get; }

        #endregion Properties
    }
}