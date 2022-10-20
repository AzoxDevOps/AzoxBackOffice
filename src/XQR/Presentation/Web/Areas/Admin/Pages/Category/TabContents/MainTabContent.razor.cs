namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Category.TabContents
{
    using Azox.Core.Extensions;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;

    using Microsoft.AspNetCore.Components;

    using System.Linq.Expressions;

    public partial class MainTabContent
    {

        #region Injects

        [Inject]
        private IMerchantServeService MerchantServeService { get; set; }

        #endregion Injects

        #region Parameters

        [CascadingParameter]
        public CategoryDto Model { get; set; }

        #endregion Parameters

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            FillMerchantServices();
        }

        private void FillMerchantServices()
        {
            Expression<Func<MerchantServe, bool>> predicate = x => !x.IsDeleted;

            if (UserGroupType != UserGroupType.Admin)
            {
                predicate = predicate.And(x => UserServices.Contains(x.Id));
            }
            MerchantServices = MerchantServeService.Filter<MerchantServeDto>(predicate);
        }

        #endregion Methods

        #region Properties

        private IEnumerable<MerchantServeDto> MerchantServices { get; set; }

        #endregion Properties
    }
}
