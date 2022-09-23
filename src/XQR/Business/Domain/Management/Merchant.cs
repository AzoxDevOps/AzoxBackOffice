namespace Azox.XQR.Business.Domain.Management
{
    using Azox.Business.Core.Domain;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Domain.Common;
    using Azox.XQR.Business.Domain.Media;
    using Azox.XQR.Business.Domain.Region;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(Merchant), Schema = EntitySchemes.Management)]
    public class Merchant :
        DeletableBasicEntityBase
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual MerchantType MerchantType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Contact Contact { get; set; } = new();

        /// <summary>
        /// 
        /// </summary>
        public virtual Address? Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Picture? Picture { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string? FacebookLink { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string? InstagramLink { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Service> Services { get; set; }

        #endregion Properties
    }
}
