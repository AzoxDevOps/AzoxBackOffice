namespace Azox.XQR.Business.Domain.Management
{
    using Azox.Business.Core.Domain;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(License), Schema = EntitySchemes.Management)]
    public class License :
        DeletableTrackableEntityBase<int>
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual Merchant Merchant { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string LicenseKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual LicenseData LicenseData { get; set; }

        #endregion Properties
    }
}
