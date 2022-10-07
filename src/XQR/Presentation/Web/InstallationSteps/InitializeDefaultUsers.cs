namespace Azox.XQR.Presentation.Web.InstallationSteps
{
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;

    internal class InitializeDefaultUsers:
        IInstallationStep
    {
        #region Methods

        public void Install(IServiceProvider serviceProvider)
        {
            IUserService userService = serviceProvider
                .GetRequiredService<IUserService>();

            IUserGroupService userGroupService = serviceProvider
                .GetRequiredService<IUserGroupService>();

            UserGroup userGroup = userGroupService
                .SingleOrDefault(x => x.UserGroupType == UserGroupType.Admin);

            // TODO güvenlik için kompleks kullanıcı adı ve şifre seçilmeli
            userService.Register(userGroup, "admin", "P@55w0rd!");
        }

        #endregion Methods

        #region Properties

        public int Priority => 10;

        public bool IsRecurring => false;

        #endregion Properties
    }
}
