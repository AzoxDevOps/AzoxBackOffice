namespace Azox.XQR.Business.Domain.Management
{
    using Azox.Business.Core.Domain;

    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(StoreUser), Schema = EntitySchemes.Management)]
    public class StoreUser :
        TrackableEntityBase<int>
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual Store Store { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual User User { get; private set; }

        #endregion Properties
    }
}
