namespace Azox.Business.Core.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    public abstract class EntityBase<TId> :
        IEntity
        where TId : struct
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        [Key, Column(Order = 0)]
        public virtual TId Id { get; protected internal set; }

        #endregion Properties
    }
}
