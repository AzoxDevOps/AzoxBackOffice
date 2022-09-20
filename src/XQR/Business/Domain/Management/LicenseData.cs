namespace Azox.XQR.Business.Domain.Management
{
    /// <summary>
    /// 
    /// </summary>
    public readonly struct LicenseData
    {
        #region Ctor

        public LicenseData(DateTime startTime, DateTime endTime, ModuleType moduleType)
        {
            StartTime = startTime;
            EndTime = endTime;
            ModuleType = moduleType;
        }

        #endregion Ctor

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public DateTime StartTime { get; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime EndTime { get; }

        /// <summary>
        /// 
        /// </summary>
        public ModuleType ModuleType { get; }

        #endregion Properties
    }
}