namespace Azox.Business.Core.Dto
{
    using Azox.Business.Core.Domain;

    /// <summary>
    /// 
    /// </summary>
    public abstract class TrackableDtoBase<TEntity, TId> :
        DtoBase<TEntity, TId>
        where TEntity : TrackableEntityBase<TId>
        where TId : struct
    {
        #region Ctor

        public TrackableDtoBase()
        {
            CreationTime = DateTime.Now;
        }

        #endregion Ctor

        #region Methods

        public override void Init(TEntity entity)
        {
            base.Init(entity);

            CreationTime = entity.CreationTime;
        }

        #endregion Methods

        #region Properties

        public DateTime CreationTime { get; protected internal set; }

        #endregion Properties
    }
}