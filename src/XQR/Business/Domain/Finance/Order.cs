namespace Azox.XQR.Business
{
    using Azox.Business.Core.Domain;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(Order), Schema = EntitySchemes.Finance)]
    public class Order :
        DeletableTrackableEntityBase<long>
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual Location Location { get; set; }

        #endregion Properties
    }
}
