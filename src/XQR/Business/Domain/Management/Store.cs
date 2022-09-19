namespace Azox.XQR.Business.Domain.Management
{
    using Azox.Business.Core.Domain;

    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(Store), Schema = EntitySchemes.Management)]
    public class Store :
        DeletableBasicEntityBase
    {

    }
}
