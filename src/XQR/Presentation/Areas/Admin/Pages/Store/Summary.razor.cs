namespace Azox.XQR.Presentation.Areas.Admin.Pages.Store
{
    using Azox.Core.Extensions;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Data;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    [Authorize(Roles = $"{nameof(UserGroupType.Admin)}")]
    public partial class Summary
    {
        #region Injects

        [Inject]
        private IMerchantServeService StoreService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        #endregion Injects

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Model = await StoreService.GetAllAsync<MerchantServeDto>();
        }

        private async Task SummaryFilter()
        {
            FilterArgs.IsBusy = true;
            Expression<Func<MerchantServe, bool>> predicate = x => true;

            if (!FilterArgs.Name.IsNullOrEmpty())
            {
                predicate = predicate.And(x => x.Name.Contains(FilterArgs.Name));
            }

            if (FilterArgs.StoreTypeId > 0)
            {
                predicate = predicate.And(x => x.ServiceType == (MerchantServeType)FilterArgs.StoreTypeId);
            }

            Model = await StoreService.FilterAsync<MerchantServeDto>(predicate);
            FilterArgs.IsBusy = false;

            StateHasChanged();
        }

        #endregion Methods

        #region Properties

        private StoreFilterArgs FilterArgs { get; set; } = new();

        private IEnumerable<MerchantServeDto> Model { get; set; }

        #endregion Properties

        #region Nested

        private class StoreFilterArgs
        {
            public bool IsBusy { get; set; }

            public string Name { get; set; }

            public int StoreTypeId { get; set; }

            public List<SelectListItem> StoreTypes => new()
            {
                new SelectListItem
                {
                    Text = "Tümü",
                    Value = "0",
                    Selected = true
                },
                new SelectListItem
                {
                    Text = MerchantServeType.Restaurant.GetDescription(),
                    Value = MerchantServeType.Restaurant.ToString("D")
                },
                new SelectListItem
                {
                    Text = MerchantServeType.RoomService.GetDescription(),
                    Value = MerchantServeType.RoomService.ToString("D")
                },
                new SelectListItem
                {
                    Text = MerchantServeType.Spa.GetDescription(),
                    Value = MerchantServeType.Spa.ToString("D")
                }
            };
        }

        #endregion Nested
    }
}
