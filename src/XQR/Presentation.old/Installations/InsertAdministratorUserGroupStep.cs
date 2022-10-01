namespace Azox.XQR.Presentation.Installations
{
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;

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
