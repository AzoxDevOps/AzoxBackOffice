namespace Azox.XQR.Business.Domain.Order
{
    using Azox.Business.Core.Domain;
    using Azox.XQR.Business.Domain.Catalog;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(OrderItem), Schema = EntitySchemes.Finance)]
    public class OrderItem :
        DeletableTrackableEntityBase<long>
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string? Note { get; set; }

        #endregion Properties
    }
}