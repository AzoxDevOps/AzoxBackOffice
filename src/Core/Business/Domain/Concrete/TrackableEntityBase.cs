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
        #region Ctor

        protected TrackableEntityBase()
        {
            CreationTime = DateTime.UtcNow;
        }

        #endregion Ctor

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime CreationTime { get; protected internal set; }

        #endregion Properties
    }
}
