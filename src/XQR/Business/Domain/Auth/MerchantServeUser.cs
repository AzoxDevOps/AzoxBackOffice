namespace Azox.XQR.Business
{
    using Azox.Business.Core.Domain;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(MerchantServeUser), Schema = EntitySchemes.Auth)]
    public class MerchantServeUser :
        TrackableEntityBase<int>
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual MerchantServe Service { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual User User { get; set; }

        #endregion Properties
    }
}
