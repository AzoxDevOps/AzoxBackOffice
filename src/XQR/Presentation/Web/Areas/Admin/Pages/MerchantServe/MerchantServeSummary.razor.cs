namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.MerchantServe
{
    using Azox.Core.Extensions;
    using Azox.Persistence.Core.Configs;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;

    using Microsoft.AspNetCore.Components;
    using Microsoft.EntityFrameworkCore;

    using System.Linq.Expressions;

    public partial class MerchantServeSummary
    {
        #region Injects

        [Inject]
        private IMerchantServeService MerchantServeService { get; set; }

        [Inject]
        private DbConfig DbConfig { get; set; }

        #endregion Injects

        #region Methods

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (!firstRender)
            {
                DataSource = MerchantServeService.Filter<MerchantServeDto>(x => !x.IsDeleted );
                StateHasChanged();
            }
        }

        private void OnSearch()
        {
            Expression<Func<MerchantServe, bool>> predicate = x => !x.IsDeleted;

            DataSource = MerchantServeService.Filter<MerchantServeDto>(predicate);
        }

        private void OnCreate()
        {
            Navigator.NavigateTo("/admin/service/new");
        }

        private void OnEdit(int merchantServeId)
        {
            Navigator.NavigateTo($"/admin/service/{merchantServeId}");
        }

        private void OnDelete(int merchantId)
        {

        }

        #endregion Methods

        #region Properties

        public IEnumerable<MerchantServeDto> DataSource { get; set; }

        #endregion Properties
    }
}
