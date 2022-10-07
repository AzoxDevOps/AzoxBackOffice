namespace Azox.XQR.Presentation.Web.Core.Services
{
    using Azox.XQR.Business;

    /// <summary>
    /// 
    /// </summary>
    public interface ILoginService
    {
        /// <summary>
        /// 
        /// </summary>
        Task<ValidateCredentialsResult> LoginAsync(string username, string password);

        /// <summary>
        /// 
        /// </summary>
        Task LogoutAsync();
    }
}
