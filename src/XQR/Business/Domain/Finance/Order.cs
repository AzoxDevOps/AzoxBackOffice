namespace Azox.XQR.Business.Domain.Order
{
    using Azox.Business.Core.Domain;
    using Azox.XQR.Business.Domain.Management;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(Order), Schema = EntitySchemes.Finance)]
    public class Order :
        DeletableTrackableEntityBase<long>
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual Location Location { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string? Note { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<OrderItem> Items { get; set; }

        #endregion Properties
    }
}
