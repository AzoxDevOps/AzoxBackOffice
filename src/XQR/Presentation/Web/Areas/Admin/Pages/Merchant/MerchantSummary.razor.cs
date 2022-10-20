namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Merchant
{
    using Azox.Core.Extensions;
    using Azox.Persistence.Core.Configs;
    using Azox.Toolkit.Blazor.Helpers;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Core.Localization;

    using Microsoft.AspNetCore.Components;
    using Microsoft.EntityFrameworkCore;

    using System.Linq.Expressions;

    public partial class MerchantSummary
    {
        #region Fields

        private int _filterMerchantType;
        private string _filterMerchantName;

        #endregion Fields

        #region Injects

        [Inject]
        private ILogger<MerchantSummary> Logger { get; set; }

        [Inject]
        private IJsRuntimeHelper JsRuntimeHelper { get; set; }

        [Inject]
        private IMerchantService MerchantService { get; set; }

        [Inject]
        private DbConfig DbConfig { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        #endregion Injects

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            FilterDataSource(x => !x.IsDeleted);
        }

        private void FilterDataSource(Expression<Func<Merchant, bool>> predicate)
        {
            DataSource = MerchantService.Filter<MerchantDto>(predicate);
        }

        private void OnSearch()
        {
            Expression<Func<Merchant, bool>> predicate = x => !x.IsDeleted;

            if (_filterMerchantType > 0)
            {
                MerchantType merchantType = (MerchantType)_filterMerchantType;

                predicate = predicate.And(x => x.MerchantType == merchantType);
            }

            if (!_filterMerchantName.IsNullOrEmpty())
            {
                if (DbConfig.Provider == DbProvider.MsSQL)
                {
                    predicate = predicate.And(x => EF.Functions.Like(x.Name, $"%{_filterMerchantName}%"));
                }
                else if (DbConfig.Provider == DbProvider.PostgreSQL)
                {
                    predicate = predicate.And(x => EF.Functions.ILike(x.Name, $"%{_filterMerchantName}%"));
                }
            }

            FilterDataSource(predicate);
        }

        private void OnCreate()
        {
            Navigator.NavigateTo("/admin/merchant/new");
        }

        private void OnEdit(int merchantId)
        {
            Navigator.NavigateTo($"/admin/merchant/{merchantId}");
        }

        private async Task OnDelete(int merchantId)
        {
            bool confirm = await JsRuntimeHelper.GetConfirmResult(XResource.DeleteConfirm);
            if (confirm)
            {
                await Task.Run(() =>
                {
                    MerchantService.Delete(merchantId);
                    FilterDataSource(x => !x.IsDeleted);
                });
            }
        }

        #endregion Methods

        #region Properties

        public IEnumerable<MerchantDto> DataSource { get; set; }

        #endregion Properties
    }
}
