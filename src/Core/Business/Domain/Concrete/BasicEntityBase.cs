namespace Azox.Business.Core.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BasicEntityBase :
        TrackableEntityBase<int>,
        IBasicEntity
    {
        #region Ctor

        protected BasicEntityBase() { }

        protected internal BasicEntityBase(
            string name,
            string description)
        {
            Name = name;
            Description = description;
        }

        #endregion Ctor

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string? Description { get; set; }

        #endregion Properties
    }
}
