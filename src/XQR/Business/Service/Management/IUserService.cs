namespace Azox.XQR.Business
{
    using Azox.Business.Core.Service;
    using Azox.XQR.Business.Domain.Management;
    using Azox.XQR.Business.Models.Management;

    /// <summary>
    /// 
    /// </summary>
    public interface IUserService :
        IEntityService<User>
    {
        /// <summary>
        /// 
        /// </summary>
        RegisterResult Register(UserGroup userGroup, string username, string password);

        /// <summary>
        /// 
        /// </summary>
        Task<User> GetByUsernameAsync(string username);

        /// <summary>
        /// 
        /// </summary>
        Task<ValidateCredentialsResult> ValidateCredentials(string username, string password);
    }
}
