namespace Azox.XQR.Infrastructure
{
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;

    internal class UserGroupService :
        EntityServiceBase<UserGroup, UserGroupService>,
        IUserGroupService
    {
        #region Ctor

        public UserGroupService(IServiceProvider serviceProvider) :
            base(serviceProvider)
        {
        }

        #endregion Ctor
    }
}
