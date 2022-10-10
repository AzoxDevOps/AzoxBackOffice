namespace Azox.XQR.Presentation.Core.InstallationSteps
{
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;

    internal class InitializeUserGroups :
        IInstallationStep
    {
        #region Methods

        public void Install(IServiceProvider serviceProvider)
        {
            IUserGroupService userGroupService = serviceProvider
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

        #endregion Methods

        #region Properties

        public int Priority => 0;

        public bool IsRecurring => false;

        #endregion Properties
    }
}
