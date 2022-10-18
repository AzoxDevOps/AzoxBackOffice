namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Location.TabContents
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

        [Inject]
        private IMerchantServeService MerchantServeService { get; set; }

        [Inject]
        private ILocationService LocationService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        #endregion Injects

        #region Parameters

        [CascadingParameter]
        public LocationDto Model { get; set; }

        #endregion Parameters

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            FillMerchantSelectListItems();
            FillMerchantServeSelectListItems();
        }

        private void MerchantOnSelect(ChangeEventArgs e)
        {
            if (e.Value != null)
            {
                Model.Service.Merchant.Id = Convert.ToInt32(e.Value);
                FillMerchantServeSelectListItems();
            }
        }

        private void MerchantServeOnSelect(ChangeEventArgs e)
        {
            if (e.Value != null)
            {
                Model.Service.Id = Convert.ToInt32(e.Value);
            }
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
                        Selected = x.Id == Model.Service.Merchant.Id
                    });
        }

        private void FillMerchantServeSelectListItems()
        {
            MerchantServeSelectListItems = MerchantServeService
                    .Filter(x => !x.IsDeleted && x.Merchant.Id == Model.Service.Merchant.Id)
                    .Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString(),
                        Selected = x.Id == Model.Service.Id
                    });
        }

        private void SetAsActive()
        {
            LocationService.SetAsActive(Model.Id);
            Model.OnPropertyChanged?.Invoke();
        }

        private void SetAsPassive()
        {
            LocationService.SetAsPassive(Model.Id);
            Model.OnPropertyChanged?.Invoke();
        }

        #endregion Methods

        #region Properties

        private IEnumerable<SelectListItem> MerchantSelectListItems { get; set; } = new List<SelectListItem>();

        private IEnumerable<SelectListItem> MerchantServeSelectListItems { get; set; } = new List<SelectListItem>();

        #endregion Properties
    }
}
