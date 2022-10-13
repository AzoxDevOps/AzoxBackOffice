namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Merchant
{
    using Azox.Core.Extensions;
    using Azox.Persistence.Core.Configs;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;

    using Microsoft.AspNetCore.Components;
    using Microsoft.EntityFrameworkCore;

    using Radzen.Blazor;

    using System.Linq.Expressions;

    public partial class MerchantSummary
    {
        #region Fields

        private int _filterMerchantType;
        private string _filterMerchantName;

        #endregion Fields

        #region Injects

        [Inject]
        private IMerchantService MerchantService { get; set; }

        [Inject]
        private DbConfig DbConfig { get; set; }

        #endregion Injects

        #region Methods

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (!firstRender)
            {
                if (DataSource == null)
                {
                    FilterDataSource(x => !x.IsDeleted);
                    StateHasChanged();
                }
            }
        }

        private void FilterDataSource(Expression<Func<Merchant, bool>> predicate)
        {
            DataSource = MerchantService.Filter<MerchantDto>(predicate);
        }

        private async Task OnSearch()
        {
            await Task.Run(() =>
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
            });
        }

        private void OnCreate()
        {
            Navigator.NavigateTo("/admin/merchant/new");
        }

        private void OnEdit(int merchantId)
        {
            Navigator.NavigateTo($"/admin/merchant/{merchantId}");
        }

        private void OnDelete(int merchantId)
        {

        }

        #endregion Methods

        #region Properties

        public IEnumerable<MerchantDto> DataSource { get; set; }

        #endregion Properties
    }
}
