namespace Azox.Business.Core.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class DeletableBasicEntityBase :
        BasicEntityBase,
        IDeletableEntity
    {
        #region Ctor

        protected DeletableBasicEntityBase() { }

        protected internal DeletableBasicEntityBase(
            string name,
            string description) :
            base(name, description)
        {

        }

        #endregion Ctor

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
