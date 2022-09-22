namespace Azox.XQR.Business.Domain.Management
{
    /// <summary>
    /// 
    /// </summary>
    public readonly struct ServiceWorkingHour
    {
        #region Ctor

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
        public DayOfWeek DayOfWeek { get; }

        /// <summary>
        /// 
        /// </summary>
        public TimeSpan OpeningTime { get; }

        /// <summary>
        /// 
        /// </summary>
        public TimeSpan ClosingTime { get; }

        #endregion Properties
    }
}
