namespace Azox.XQR.Business
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public class MerchantServeWorkingHour
    {
        #region Ctor

        public MerchantServeWorkingHour() { }

        [JsonConstructor]
        public MerchantServeWorkingHour(DayOfWeek dayOfWeek, TimeSpan openingTime, TimeSpan closingTime)
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
