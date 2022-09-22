namespace Azox.XQR.Business.Domain.Catalog
{
    using Azox.Business.Core.Domain;
    using Azox.XQR.Business.Domain.Common;
    using Azox.XQR.Business.Domain.Management;
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
        public virtual bool IsVisible { get; set; }

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

        /// <summary>
        /// 
        /// </summary>
        // TODO içindeki malzemeler için çalışma yapılmalı
        //public virtual string? Ingredients { get; set; }

        /// <summary>
        /// 
        /// </summary>
        // TODO Dış mutfak servisi için aksiyon alınacak
        //public virtual ExternalService? ExternalService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        // TODO Dış mutfak servisi için aksiyon alınacak
        //public virtual Price? ExternalServicePrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<ProductPicture> Pictures { get; set; }


        #endregion Properties
    }
}
