namespace Azox.XQR.Presentation.Installations
{
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Domain.Management;

    /// <summary>
    /// 
    /// </summary>
    internal class InsertAdministratorUserGroupStep :
        IInstallationStep
    {
        public void Install(IServiceProvider serviceProvider)
        {
            IUserGroupService userGroupService = serviceProvider
                .GetRequiredService<IUserGroupService>();

            UserGroup userGroup = new UserGroup
            {
                Name = "Sistem Yöneticisi",
                UserGroupType = UserGroupType.Admin
            };

            userGroupService.Insert(userGroup);
        }
    }
}
