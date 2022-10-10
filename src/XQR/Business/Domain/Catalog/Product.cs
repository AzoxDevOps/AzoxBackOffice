namespace Azox.XQR.Business
{
    using Azox.Business.Core.Domain;

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
        public virtual bool IsActive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual int DisplayOrder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Price Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Price OldPrice { get; set; }

        #endregion Properties
    }
}
