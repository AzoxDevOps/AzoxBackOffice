﻿namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.MerchantServe
{
    using Azox.Core.Extensions;
    using Azox.Toolkit.Blazor.Helpers;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Core.Localization;

    using Microsoft.AspNetCore.Components;

    using System.Linq.Expressions;

    public partial class MerchantServeSummary
    {
        #region Injects

        [Inject]
        private IJsRuntimeHelper JsRuntimeHelper { get; set; }

        [Inject]
        private IMerchantServeService MerchantServeService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        #endregion Injects

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            FilterDataSource(x => !x.IsDeleted && !x.Merchant.IsDeleted);
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

            FilterDataSource(predicate);
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

        public IEnumerable<MerchantServeDto> DataSource { get; set; }

        #endregion Properties
    }
}
