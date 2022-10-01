namespace Azox.XQR.Presentation.Areas.Admin.Pages.Merchant
{
    using Azox.Core.Extensions;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public partial class Summary
    {
        #region Injects

        [Inject]
        private IMerchantService MerchantService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        #endregion Injects

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Model = await MerchantService.GetAllAsync<MerchantDto>();
        }

        private async Task SummaryFilter()
        {
            FilterArgs.IsBusy = true;
            Expression<Func<Merchant, bool>> predicate = x => true;

            if (!FilterArgs.Name.IsNullOrEmpty())
            {
                predicate = predicate.And(x => x.Name.Contains(FilterArgs.Name));
            }

            if (FilterArgs.MerchantTypeId > 0)
            {
                predicate = predicate.And(x => x.MerchantType == (MerchantType)FilterArgs.MerchantTypeId);
            }

            Model = await MerchantService.FilterAsync<MerchantDto>(predicate);
            FilterArgs.IsBusy = false;

            StateHasChanged();
        }

        #endregion Methods

        #region Properties

        private MerchantFilterArgs FilterArgs { get; set; } = new();

        private IEnumerable<MerchantDto> Model { get; set; }

        #endregion Properties

        #region Nested

        private class MerchantFilterArgs
        {
            public bool IsBusy { get; set; }

            public string Name { get; set; }

            public int MerchantTypeId { get; set; }

            public List<SelectListItem> MerchantTypes => new()
            {
                new SelectListItem
                {
                    Text = "Tümü",
                    Value = "0",
                    Selected = true,
                },
                new SelectListItem
                {
                    Text = MerchantType.Restaurant.GetDescription(),
                    Value = MerchantType.Restaurant.ToString("D")
                },
                new SelectListItem
                {
                    Text = MerchantType.Hotel.GetDescription(),
                    Value = MerchantType.Hotel.ToString("D")
                }
            };
        }

        #endregion Nested
    }
}
