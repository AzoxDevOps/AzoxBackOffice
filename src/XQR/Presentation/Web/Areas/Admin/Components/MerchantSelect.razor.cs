namespace Azox.XQR.Presentation.Web.Areas.Admin.Components
{
    using Azox.Business.Core.Extensions;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;

    using Microsoft.AspNetCore.Components;

    using System.Threading.Tasks;

    public partial class MerchantSelect
    {
        #region Fields

        private int _merchantId;

        #endregion Fields

        #region Injects

        [Inject]
        private IMerchantService MerchantService { get; set; }

        [Inject]
        private IMerchantServeService MerchantServeService { get; set; }

        #endregion Injects

        #region Parameters

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public int MerchantId
        {
            get => _merchantId;
            set
            {
                if(_merchantId != value)
                {
                    _merchantId = value;
                    MerchantIdChanged.InvokeAsync(value);
                }
            }
        }

        [Parameter]
        public bool ShowAllSelectItem { get; set; }

        [Parameter]
        public EventCallback<int> MerchantIdChanged { get; set; }

        #endregion Parameters

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if (UserGroupType == UserGroupType.Admin)
            {
                DataSource = MerchantService
                    .Filter<MerchantDto>(x => !x.IsDeleted)
                    .ToList();
            }
            else
            {
                DataSource = new List<MerchantDto>();
                var merchants = MerchantServeService
                    .Filter(x => !x.IsDeleted && UserServices.Contains(x.Id))
                    .Select(x => x.Merchant);

                foreach (var item in merchants)
                {
                    if (!DataSource.Any(x => x.Id == item.Id))
                    {
                        DataSource.Add(item.ToDto<Merchant, MerchantDto>());
                    }
                }
            }
        }

        #endregion Methods

        #region Properties

        private IList<MerchantDto> DataSource { get; set; }

        #endregion Properties
    }
}
