namespace Azox.XQR.Presentation.Areas.Admin.Models
{
    using Azox.Business.Core.Domain;

    /// <summary>
    /// 
    /// </summary>
    public abstract class TrackableEntityModelBase<TEntity, TId> :
        EntityModelBase<TEntity, TId>
        where TId : struct
        where TEntity : TrackableEntityBase<TId>
    {
        #region Ctor

        public TrackableEntityModelBase()
        {
            CreationTime = DateTime.Now;
        }

        public TrackableEntityModelBase(TEntity entity) :
            base(entity)
        {
            CreationTime = entity.CreationTime;
        }

        #endregion Ctor

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreationTime { get; set; }

        #endregion Properties
    }
}