namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Location.TabContents
{
    using Azox.Business.Core;
    using Azox.Business.Core.Data;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;

    using Microsoft.AspNetCore.Components;

    public partial class OrderTabContent
    {
        #region Injects

        [Inject]
        private IOrderService OrderService { get; set; }

        #endregion Injects

        #region Parameters

        [CascadingParameter]
        public LocationDto Model { get; set; }

        #endregion Parameters

        protected override void OnParametersSet()
        {
            DataSource = OrderService
                .Filter<OrderDto>(x => x.Location.Id == Model.Id && !x.IsDeleted,
                new SortProvider<Order> { Predicate = x => x.CreationTime, SortOrder = SortOrder.Descending });
        }

        #region Properties

        private IEnumerable<OrderDto> DataSource { get; set; }

        #endregion Properties
    }
}
