namespace Azox.XQR.Business
{
    using Azox.Business.Core.Service;

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
        Task<bool> UpdatePassword(string username, string password);

        /// <summary>
        /// 
        /// </summary>
        Task<ValidateCredentialsResult> ValidateCredentials(string username, string password);
    }
}
