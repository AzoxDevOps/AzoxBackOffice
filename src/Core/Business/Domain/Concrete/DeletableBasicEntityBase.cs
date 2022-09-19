namespace Azox.Business.Core.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class DeletableBasicEntityBase :
        BasicEntityBase,
        IDeletableEntity
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsDeleted { get; protected internal set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? DeletionTime { get; protected internal set; }

        #endregion Properties
    }
}
