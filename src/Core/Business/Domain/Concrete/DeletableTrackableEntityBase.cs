namespace Azox.Business.Core.Domain
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public abstract class DeletableTrackableEntityBase<TId> :
        TrackableEntityBase<TId>,
        IDeletableEntity
        where TId : struct
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsDeleted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //public virtual bool IsPermanentlyDeleted { get; protected internal set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? DeletionTime { get; set; }

        #endregion Properties
    }
}
