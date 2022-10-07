namespace Azox.XQR.Presentation.Web.Areas.Admin.Services
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
