namespace Azox.XQR.Presentation.Installations
{
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;
    using System;

    internal class InsertDefaultAdminUserStep :
        IInstallationStep
    {
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
    }
}
