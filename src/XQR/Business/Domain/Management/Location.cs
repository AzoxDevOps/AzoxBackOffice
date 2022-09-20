namespace Azox.XQR.Business.Domain.Management
{
    using Azox.Business.Core.Domain;
    using Azox.XQR.Business;
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
        public virtual Service Service { get; set; }

        #endregion Properties
    }
}
