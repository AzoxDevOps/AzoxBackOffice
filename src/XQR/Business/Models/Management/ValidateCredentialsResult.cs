namespace Azox.XQR.Business.Models.Management
{
    /// <summary>
    /// 
    /// </summary>
    public class ValidateCredentialsResult
    {
        #region Static Methods

        public static ValidateCredentialsResult InvalidUsernameOrPassword()
        {
            return new ValidateCredentialsResult
            {
                Success = false
            };
        }

        public static ValidateCredentialsResult InactiveUser()
        {
            return new ValidateCredentialsResult
            {
                Success = false
            };
        }

        public static ValidateCredentialsResult LockedUser()
        {
            return new ValidateCredentialsResult
            {
                Success = false
            };
        }

        public static ValidateCredentialsResult Succeeded()
        {
            return new ValidateCredentialsResult
            {
                Success = true
            };
        }

        #endregion Static Methods

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public bool Success { get; internal set; }

        #endregion Properties
    }
}
