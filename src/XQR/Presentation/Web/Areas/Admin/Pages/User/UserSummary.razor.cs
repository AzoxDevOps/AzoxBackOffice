namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.User
{
    using Azox.Business.Core.Extensions;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Web.Areas.Admin.Components;

    using Microsoft.AspNetCore.Components;

    public partial class UserSummary :
        Summary<UserDto>
    {
        #region Injects

        [Inject]
        private IUserService UserService { get; set; }

        #endregion Injects

        #region Methods

        protected override void InitializeDataSource(UserGroupType userGroupType, int merchantId, int serviceId)
        {
            if (userGroupType == UserGroupType.Admin)
            {
                DataSource = UserService.Filter<UserDto>(x => !x.IsDeleted);
            }
            else if (userGroupType == UserGroupType.MerchantAdmin)
            {
                DataSource = MerchantServeUserService
                    .Filter(x => x.Service.Merchant.Id == merchantId && !x.User.IsDeleted)
                    .Select(x => x.User.ToDto<User, UserDto>());
            }
            else if (userGroupType == UserGroupType.ServiceAdmin)
            {
                DataSource = MerchantServeUserService
                    .Filter(x => x.Service.Id == serviceId && !x.User.IsDeleted)
                    .Select(x => x.User.ToDto<User, UserDto>());
            }
        }

        protected override void OnDelete(int id)
        {

        }

        #endregion Methods

        #region Properties

        protected override string DetailUrl => "user";

        #endregion Properties
    }
}
