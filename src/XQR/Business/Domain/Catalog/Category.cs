namespace Azox.XQR.Business.Domain.Catalog
{
    using Azox.Business.Core.Domain;
    using Azox.XQR.Business.Domain.Media;

    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(Category), Schema = EntitySchemes.Catalog)]
    public class Category :
        DeletableBasicEntityBase
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual Category? Parent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Picture? Picture { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        #endregion Properties
    }
}
