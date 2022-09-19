namespace Azox.XQR.Business.Domain.Catalog
{
    using Azox.Business.Core.Domain;
    using Azox.XQR.Business.Domain.Media;

    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(Product), Schema = EntitySchemes.Catalog)]
    public class Product :
        DeletableBasicEntityBase
    {
        #region Properties

        public virtual Category Category { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool Published { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual int DisplayOrder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<ProductPicture> Pictures { get; set; } = new List<ProductPicture>();

        #endregion Properties
    }
}
