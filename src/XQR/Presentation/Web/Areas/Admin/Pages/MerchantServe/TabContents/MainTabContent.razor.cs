namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.MerchantServe.TabContents
{
    using Azox.Core.Extensions;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using System.Linq.Expressions;

    public partial class MainTabContent
    {
        #region Injects


        [Inject]
        private IMerchantService MerchantService { get; set; }

        #endregion Injects

        #region Parameters

        [CascadingParameter]
        public MerchantServeDto Model { get; set; }

        #endregion Parameters

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            FillMerchantSelectListItems();
        }

        private void FillMerchantSelectListItems()
        {
            Expression<Func<Merchant, bool>> predicate = x => !x.IsDeleted;

            if (UserGroupType != UserGroupType.Admin)
            {
                predicate = predicate.And(x => UserServices.Contains(x.Id));
            }

            MerchantSelectListItems = MerchantService
                    .Filter(predicate)
                    .Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString(),
                        Selected = x.Id == Model.Merchant.Id
                    });
        }

        #endregion Methods

        #region Properties

        private IEnumerable<SelectListItem> MerchantSelectListItems { get; set; } = new List<SelectListItem>();

        #endregion Properties
    }
}
