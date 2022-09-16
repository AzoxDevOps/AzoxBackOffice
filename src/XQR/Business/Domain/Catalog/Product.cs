namespace Azox.XQR.Business.Domain.Catalog
{
    using Azox.Business.Core.Domain;

    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(Product), Schema = EntitySchemes.Catalog)]
    public class Product:
        DeletableBasicEntityBase
    {
        #region Ctor

        protected Product() { }

        protected internal Product(
            string name,
            string description) :
            base(name, description)
        {

        }

        #endregion Ctor
    }
}
