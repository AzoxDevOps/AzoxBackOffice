namespace Azox.XQR.Business
{
    /// <summary>
    /// 
    /// </summary>
    public enum ValidateCredentialsResult
    {
        /// <summary>
        /// 
        /// </summary>
        InvalidUsernameOrPassword,

        /// <summary>
        /// 
        /// </summary>
        InactiveUser,

        /// <summary>
        /// 
        /// </summary>
        LockedUser,

        /// <summary>
        /// 
        /// </summary>
        PasswordChangeOnFirstLogin,

        /// <summary>
        /// 
        /// </summary>
        Succeeded
    }
}
