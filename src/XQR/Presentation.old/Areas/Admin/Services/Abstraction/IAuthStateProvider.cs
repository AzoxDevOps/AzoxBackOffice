namespace Azox.XQR.Presentation.Areas.Admin.Services
{
    using Azox.XQR.Presentation.Areas.Admin.Models;

    /// <summary>
    /// 
    /// </summary>
    public interface IAuthStateProvider
    {
        /// <summary>
        /// 
        /// </summary>
        Task<ValidateCredentialsResult> LoginAsync(LoginModel loginModel);
    }
}