namespace Azox.XQR.Business.Domain.Media
{
    using Azox.Business.Core.Domain;

    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(Picture), Schema = EntitySchemes.Media)]
    public class Picture :
        DeletableTrackableEntityBase<Guid>
    {
    }
}
