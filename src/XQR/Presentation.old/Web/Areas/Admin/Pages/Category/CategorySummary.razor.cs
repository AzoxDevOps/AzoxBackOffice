namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Category
{
    using Azox.Core.Extensions;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Web.Areas.Admin.Services;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Components;

    using System.Linq.Expressions;

    [Authorize(Roles = $"{nameof(UserGroupType.Admin)}, {nameof(UserGroupType.MerchantAdmin)}, {nameof(UserGroupType.ServiceAdmin)}")]
    public partial class CategorySummary
    {
        #region Injects

        [Inject]
        private IAuthService AuthService { get; set; }

        [Inject]
        private ICategoryService CategoryService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        #endregion Injects

        #region Methods

        private async Task FilterDataSource(Expression<Func<Category, bool>>? predicate = null)
        {
            UserGroupType userGroupType = await AuthService.GetUserGroupType();

            predicate ??= x => !x.IsDeleted;

            if (userGroupType == UserGroupType.MerchantAdmin)
            {
                int merchantId = await AuthService.GetMerchantId();
                predicate = predicate.And(x => x.Service.Merchant.Id == merchantId);
            }
            else if (userGroupType == UserGroupType.ServiceAdmin)
            {
                int serviceId = await AuthService.GetServiceId();
                predicate = predicate.And(x => x.Service.Id == serviceId);
            }

            DataSource = CategoryService.Filter<CategoryDto>(predicate, x => x.DisplayOrder);
        }

        private void Create()
        {
            Navigator.NavigateTo("/admin/category/new");
        }

        protected override async void OnInitialized()
        {
            await FilterDataSource();
        }

        #endregion Methods

        #region Properties

        private IEnumerable<CategoryDto> DataSource { get; set; }

        #endregion Properties
    }
}
