namespace Azox.XQR.Infrastructure
{
    using Azox.Business.Core.Data;
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Domain.Management;

    internal class UserService :
        EntityServiceBase<User>,
        IUserService
    {
        #region Ctor

        public UserService(IRepository<User> repository) :
            base(repository)
        {
        }

        #endregion Ctor

    }
}
