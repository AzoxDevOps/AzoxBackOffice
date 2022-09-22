namespace Azox.XQR.Business.Domain.Management
{
    using Azox.Business.Core.Domain;
    using Azox.XQR.Business.Domain.Common;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(ExternalService), Schema = EntitySchemes.Management)]
    public class ExternalService :
        DeletableBasicEntityBase
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual Merchant Merchant { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Contact Contact { get; set; }

        #endregion Properties
    }
}
