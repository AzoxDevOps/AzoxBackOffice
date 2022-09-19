namespace Azox.XQR.Business.Domain.Media
{
    using Azox.Business.Core.Domain;
    using Azox.XQR.Business.Domain.Catalog;

    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(ProductPicture), Schema = EntitySchemes.Media)]
    public class ProductPicture :
        DeletableTrackableEntityBase<int>
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Picture Picture { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool Published { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual int DisplayOrder { get; set; }

        #endregion Properties
    }
}
