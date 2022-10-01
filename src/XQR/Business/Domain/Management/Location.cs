namespace Azox.XQR.Business
{
    using Azox.Business.Core.Domain;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(Location), Schema = EntitySchemes.Management)]
    public class Location :
        DeletableBasicEntityBase
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual MerchantServe Service { get; set; }

        #endregion Properties
    }
}
