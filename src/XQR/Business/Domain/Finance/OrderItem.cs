namespace Azox.XQR.Business
{
    using Azox.Business.Core.Domain;
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
        public virtual Price UnitPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual int Quantity { get; set; }

        #endregion Properties
    }
}