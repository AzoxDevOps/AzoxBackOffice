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
        /// DB' den silinmesin
        /// </summary>
        public virtual bool IsDeleted { get; set; }

        /// <summary>
        /// DB' den periyodik olarak kontrollü bir şekilde servis tarafından silinsin.
        /// </summary>
        //public virtual bool IsPermanentlyDeleted { get; protected internal set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? DeletionTime { get; set; }

        #endregion Properties
    }
}
