namespace Azox.XQR.Business.Domain.Management
{
    using Azox.Business.Core.Domain;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Domain.Common;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(Service), Schema = EntitySchemes.Management)]
    public class Service :
        DeletableBasicEntityBase
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual ServiceType ServiceType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Merchant Merchant { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Contact> Contacts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Location> Locations { get; set; }

    }
}
