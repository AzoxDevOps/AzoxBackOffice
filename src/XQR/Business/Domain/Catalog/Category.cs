namespace Azox.XQR.Business
{
    using Azox.Business.Core.Domain;

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
        public virtual MerchantServe Service { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsVisible { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual int DisplayOrder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Category? Parent { get; set; }

        #endregion Properties
    }
}
