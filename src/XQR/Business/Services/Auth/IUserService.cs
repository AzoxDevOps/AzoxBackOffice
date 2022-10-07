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
        User GetByUsername(string username);

        /// <summary>
        /// 
        /// </summary>
        bool UpdatePassword(string username, string password);

        /// <summary>
        /// 
        /// </summary>
        ValidateCredentialsResult ValidateCredentials(string username, string password);
    }
}
