namespace Azox.XQR.Presentation.Web.Core.InstallationSteps
{
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;

    /// <summary>
    /// 
    /// </summary>
    internal class InsertUserGroupsStep :
        IInstallationStep
    {
        public void Install(IServiceProvider serviceProvider)
        {
            IUserGroupService userGroupService = serviceProvider
                .CreateScope().ServiceProvider
                .GetRequiredService<IUserGroupService>();

            userGroupService.InsertRange(new List<UserGroup>
            {
                new UserGroup
                {
                    Name="Sistem Yöneticileri",
                    UserGroupType = UserGroupType.Admin
                },
                new UserGroup
                {
                    Name="İşletme Yöneticileri",
                    UserGroupType = UserGroupType.MerchantAdmin
                },
                new UserGroup
                {
                    Name="Hizmet Yöneticileri",
                    UserGroupType = UserGroupType.ServiceAdmin
                },
                new UserGroup
                {
                    Name="Hizmet Kullanıcıları",
                    UserGroupType = UserGroupType.ServiceUser
                }
            });
        }

        public int Priority => 0;
    }
}
