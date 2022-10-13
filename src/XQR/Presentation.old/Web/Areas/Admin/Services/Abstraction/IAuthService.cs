namespace Azox.XQR.Presentation.Web.Areas.Admin.Services
{
    using Azox.Core;
    using Azox.Toolkit.Blazor;
    using Azox.XQR.Business;

    /// <summary>
    /// 
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// 
        /// </summary>
        Task<UserGroupType> GetUserGroupType();

        /// <summary>
        /// 
        /// </summary>
        Task<int> GetMerchantId();

        /// <summary>
        /// 
        /// </summary>
        Task<int> GetServiceId();

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
