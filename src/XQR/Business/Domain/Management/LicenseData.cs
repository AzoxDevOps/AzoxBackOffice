namespace Azox.XQR.Business.Domain.Management
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public class LicenseData
    {
        #region Ctor

        [JsonConstructor]
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
        public DateTime StartTime { get; set;  }

        /// <summary>
        /// 
        /// </summary>
        public DateTime EndTime { get; set;  }

        /// <summary>
        /// 
        /// </summary>
        public ModuleType ModuleType { get; set;  }

        #endregion Properties
    }
}