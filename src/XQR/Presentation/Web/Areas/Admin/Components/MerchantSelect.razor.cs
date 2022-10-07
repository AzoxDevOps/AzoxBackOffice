namespace Azox.XQR.Presentation.Web.Areas.Admin.Components
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;

    using System.Security.Claims;
    using System.Threading.Tasks;

    public partial class MerchantSelect
    {
        #region Injects

        [Inject]
        private IMerchantService MerchantService { get; set; }

        [Inject]
        private IMerchantServeUserService MerchantServeUserService { get; set; }

        [Inject]
        private AuthenticationStateProvider AuthStateProvider { get; set; }

        #endregion Injects

        #region Parameters

        [Parameter]
        public int MerchantId { get; set; }

        #endregion Parameters

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            AuthenticationState authenticationState = await AuthStateProvider
                .GetAuthenticationStateAsync();

            string username = authenticationState.User.Identity.Name;
            string userRole = authenticationState.User.FindFirstValue(ClaimTypes.Role);

            if (Enum.TryParse<UserGroupType>(userRole, out UserGroupType userGroupType))
            {
                if (userGroupType == UserGroupType.Admin)
                {
                    DataSource = MerchantService.Filter<MerchantDto>(x => !x.IsDeleted);
                }
                else if (userGroupType == UserGroupType.MerchantAdmin
                    || userGroupType == UserGroupType.ServiceAdmin)
                {
                    DataSource = MerchantServeUserService
                        .Filter(x => x.User.Username == username)
                        .Select(x =>
                        {
                            MerchantDto dto = new MerchantDto();
                            dto.Init(x.Service.Merchant);

                            return dto;
                        });
                }
                else
                {
                    DataSource = new List<MerchantDto>();
                }
            }
        }

        #endregion Methods

        #region Properties

        private IEnumerable<MerchantDto> DataSource { get; set; }

        #endregion Properties
    }
}
