namespace Azox.XQR.Business.Domain.Region
{
    using Azox.Business.Core.Domain;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(City), Schema = EntitySchemes.Region)]
    public class City :
        DeletableBasicEntityBase
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<District> Districts { get; set; }

        #endregion Properties
    }
}
