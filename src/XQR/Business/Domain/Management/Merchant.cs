namespace Azox.XQR.Business
{
    using Azox.Business.Core.Domain;

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
        public virtual bool IsActive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual MerchantType MerchantType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Contact Contact { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Address Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Picture Picture { get; set; }

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
        public virtual List<MerchantServe> Services { get; set; }

        #endregion Properties
    }
}
