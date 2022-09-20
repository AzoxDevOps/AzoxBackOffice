namespace Azox.XQR.Business.Domain.Region
{
    using Azox.Business.Core.Domain;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(Address), Schema = EntitySchemes.Region)]
    public class Address :
        TrackableEntityBase<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual City City { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual District District { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string AddressLine { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual double? Latitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual double? Longitude { get; set; }
    }
}