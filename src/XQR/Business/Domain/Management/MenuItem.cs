namespace Azox.XQR.Business.Domain.Management
{
    using Azox.Business.Core.Domain;

    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(MenuItem), Schema = EntitySchemes.Management)]
    public class MenuItem :
        DeletableBasicEntityBase
    {
        #region Ctor

        protected MenuItem() { }

        protected internal MenuItem(
            string name,
            string description) :
            base(name, description)
        {

        }

        #endregion Ctor
    }
}
