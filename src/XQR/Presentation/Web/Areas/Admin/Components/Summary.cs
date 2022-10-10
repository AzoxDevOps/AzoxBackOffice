namespace Azox.XQR.Presentation.Web.Areas.Admin.Components
{
    using Azox.Core;
    using Azox.XQR.Business;
    using Azox.XQR.Presentation.Web.Areas.Admin.Localization;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.JSInterop;

    using System.Security.Claims;

    public abstract class Summary<TDataSource> :
        ComponentBase
    {
        #region Injects

        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        [Inject]
        protected IMerchantServeUserService MerchantServeUserService { get; set; }

        [Inject]
        protected AuthenticationStateProvider AuthStateProvider { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        #endregion Injects

        #region Methods

        protected abstract void InitializeDataSource(UserGroupType userGroupType, int merchantId, int serviceId);

        protected abstract void OnDelete(int id);

        protected override async Task OnInitializedAsync()
        {
            AuthenticationState authenticationState = await AuthStateProvider
                .GetAuthenticationStateAsync();

            string username = authenticationState.User.Identity.Name;
            string userRole = authenticationState.User.FindFirstValue(ClaimTypes.Role);

            if (Enum.TryParse<UserGroupType>(userRole, out UserGroupType userGroupType))
            {
                int merchantId = 0;
                int serviceId = 0;

                if (userGroupType != UserGroupType.Admin)
                {
                    var services = MerchantServeUserService
                        .Filter(x => x.User.Username == username)
                        .Select(x => x.Service);

                    if (services == null || !services.Any())
                    {
                        throw new AzoxBugException();
                    }

                    merchantId = services.FirstOrDefault().Merchant.Id;

                    if (userGroupType == UserGroupType.ServiceAdmin)
                    {
                        serviceId = services.FirstOrDefault().Id;
                    }
                }

                InitializeDataSource(userGroupType, merchantId, serviceId);
            }
        }

        protected void Create()
        {
            Navigation.NavigateTo($"/admin/{DetailUrl}/new");
        }

        protected void Edit(int id)
        {
            Navigation.NavigateTo($"/admin/{DetailUrl}/{id}");
        }

        protected async Task Delete(int id)
        {
            if (await JsRuntime.InvokeAsync<bool>("confirm", Resources.DeleteConfirm))
            {
                OnDelete(id);
            }
        }

        #endregion Methods

        #region Properties

        protected IEnumerable<TDataSource> DataSource { get; set; }

        protected abstract string DetailUrl { get; }

        #endregion Properties
    }
}
