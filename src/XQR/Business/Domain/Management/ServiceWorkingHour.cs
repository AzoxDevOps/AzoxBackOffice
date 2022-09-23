namespace Azox.XQR.Business.Domain.Management
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public class ServiceWorkingHour
    {
        #region Ctor

        [JsonConstructor]
        public ServiceWorkingHour(DayOfWeek dayOfWeek, TimeSpan openingTime, TimeSpan closingTime)
        {
            DayOfWeek = dayOfWeek;
            OpeningTime = openingTime;
            ClosingTime = closingTime;
        }

        #endregion Ctor

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public DayOfWeek DayOfWeek { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TimeSpan OpeningTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TimeSpan ClosingTime { get; set; }

        #endregion Properties
    }
}
