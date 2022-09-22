namespace Azox.Business.Core.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class TrackableEntityBase<TId> :
        EntityBase<TId>,
        ITrackableEntity
        where TId : struct
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime CreationTime { get; set; } = DateTime.Now;

        #endregion Properties
    }
}
