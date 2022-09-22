namespace Azox.XQR.Infrastructure
{
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Domain.Management;
    using Microsoft.Extensions.Logging;

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

        #region Methods

        public void Insert(UserGroup userGroup)
        {
            try
            {
                Repository.Insert(userGroup);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
            }
        }

        public async Task InsertAsync(UserGroup userGroup)
        {
            try
            {
                await Repository.InsertAsync(userGroup);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
            }
        }

        #endregion Methods
    }
}
