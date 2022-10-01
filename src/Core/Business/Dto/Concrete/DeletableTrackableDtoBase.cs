namespace Azox.Business.Core.Dto
{
    using Azox.Business.Core.Domain;

    /// <summary>
    /// 
    /// </summary>
    public abstract class DeletableTrackableDtoBase<TEntity, TId> :
        TrackableDtoBase<TEntity, TId>
        where TEntity : DeletableTrackableEntityBase<TId>
        where TId : struct
    {
        #region Methods

        public override void Init(TEntity entity)
        {
            base.Init(entity);

            IsDeleted = entity.IsDeleted;
            DeletionTime = entity.DeletionTime;
        }

        #endregion Methods

        #region Properties

        public bool IsDeleted { get; set; }

        public DateTime? DeletionTime { get; set; }

        #endregion Properties
    }
}
