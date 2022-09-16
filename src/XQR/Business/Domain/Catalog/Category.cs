namespace Azox.XQR.Business.Domain.Catalog
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
        #region Ctor

        protected Category() { }

        protected internal Category(
            string name,
            string description) :
            base(name, description)
        {

        }

        #endregion Ctor
    }
}
