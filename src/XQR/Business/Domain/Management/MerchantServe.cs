namespace Azox.XQR.Business
{
    using Azox.Business.Core.Domain;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(MerchantServe), Schema = EntitySchemes.Management)]
    public class MerchantServe :
        DeletableBasicEntityBase
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsActive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Currency Currency { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual MerchantServeType ServiceType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string? ThemeTypeName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Merchant Merchant { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual List<Contact> Contacts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual List<MerchantServeWorkingHour> WorkingHours { get; set; }
    }
}
