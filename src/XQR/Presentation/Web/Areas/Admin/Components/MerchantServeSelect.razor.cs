namespace Azox.XQR.Presentation.Web.Areas.Admin.Components
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;

    using Microsoft.AspNetCore.Components;

    public partial class MerchantServeSelect
    {
        #region Fields

        private int _merchantServeId;

        #endregion Fields

        #region Injects

        [Inject]
        private IMerchantServeService MerchantServeService { get; set; }

        #endregion Injects

        #region Parameters

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public int MerchantServeId
        {
            get => _merchantServeId;
            set
            {
                if (_merchantServeId != value)
                {
                    _merchantServeId = value;
                    MerchantServeIdChanged.InvokeAsync(value);
                }
            }
        }

        [Parameter]
        public bool ShowAllSelectItem { get; set; }

        [Parameter]
        public EventCallback<int> MerchantServeIdChanged { get; set; }

        #endregion Parameters

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if (UserGroupType == UserGroupType.Admin)
            {
                DataSource = MerchantServeService
                    .Filter<MerchantServeDto>(x => !x.IsDeleted && !x.Merchant.IsDeleted)
                    .ToList();
            }
            else
            {
                DataSource = MerchantServeService
                    .Filter<MerchantServeDto>(x => !x.IsDeleted && !x.Merchant.IsDeleted && UserServices.Contains(x.Id));

            }
        }

        #endregion Methods

        #region Properties

        private IEnumerable<MerchantServeDto> DataSource { get; set; }

        #endregion Properties
    }
}
