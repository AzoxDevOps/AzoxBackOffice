namespace Azox.XQR.Business.Domain.Region
{
    using Azox.Business.Core.Domain;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(District), Schema = EntitySchemes.Region)]
    public class District :
        DeletableBasicEntityBase
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual string? Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual City City { get; set; }

        #endregion Properties
    }
}
