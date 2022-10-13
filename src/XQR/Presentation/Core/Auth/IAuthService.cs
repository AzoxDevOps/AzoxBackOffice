namespace Azox.XQR.Presentation.Core.Auth
{
    using Azox.XQR.Business;

    /// <summary>
    /// 
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// 
        /// </summary>
        Task<ValidateCredentialsResult> SignIn(string username, string password);

        /// <summary>
        /// 
        /// </summary>
        Task SignOut();
    }
}