namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.MerchantServe
{
    using Azox.Core.Extensions;
    using Azox.Persistence.Core.Configs;
    using Azox.Toolkit.Blazor.Helpers;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Core.Localization;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    using System.Linq.Expressions;

    public partial class MerchantServeSummary
    {
        #region Fields

        private int _filterMerchantId;
        private string _filterMerchantServeName;

        #endregion Fields

        #region Injects

        [Inject]
        private IJsRuntimeHelper JsRuntimeHelper { get; set; }

        [Inject]
        private IMerchantService MerchantService { get; set; }

        [Inject]
        private IMerchantServeService MerchantServeService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        [Inject]
        private DbConfig DbConfig { get; set; }

        #endregion Injects

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            FilterDataSource(x => !x.IsDeleted && !x.Merchant.IsDeleted);
            FillMerchantSelectListItems();
        }

        private void FilterDataSource(Expression<Func<MerchantServe, bool>> predicate)
        {
            if (UserServices.Any())
            {
                predicate = predicate.And(x => UserServices.Contains(x.Id));
            }

            DataSource = MerchantServeService.Filter<MerchantServeDto>(predicate);
        }

        private void OnSearch()
        {
            Expression<Func<MerchantServe, bool>> predicate = x => !x.IsDeleted && !x.Merchant.IsDeleted;

            if (_filterMerchantId > 0)
            {
                predicate = predicate.And(x => x.Merchant.Id == _filterMerchantId);
            }

            if (!_filterMerchantServeName.IsNullOrEmpty())
            {
                if (DbConfig.Provider == DbProvider.MsSQL)
                {
                    predicate = predicate.And(x => EF.Functions.Like(x.Name, $"%{_filterMerchantServeName}%"));
                }
                else
                {
                    predicate = predicate.And(x => EF.Functions.ILike(x.Name, $"%{_filterMerchantServeName}%"));
                }
            }

            FilterDataSource(predicate);
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
                    });
        }

        private void OnCreate()
        {
            Navigator.NavigateTo("/admin/service/new");
        }

        private void OnEdit(int merchantServeId)
        {
            Navigator.NavigateTo($"/admin/service/{merchantServeId}");
        }

        private async Task OnDelete(int merchantServeId)
        {
            bool confirm = await JsRuntimeHelper.GetConfirmResult(Resources.DeleteConfirm);
            if (confirm)
            {
                await Task.Run(() =>
                {
                    MerchantServeService.Delete(merchantServeId);
                    FilterDataSource(x => !x.IsDeleted);
                });
            }
        }

        #endregion Methods

        #region Properties

        private IEnumerable<SelectListItem> MerchantSelectListItems { get; set; } = new List<SelectListItem>();

        public IEnumerable<MerchantServeDto> DataSource { get; set; }

        #endregion Properties
    }
}
