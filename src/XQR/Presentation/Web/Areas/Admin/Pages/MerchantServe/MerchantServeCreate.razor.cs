namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.MerchantServe
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;

    using Microsoft.AspNetCore.Components;

    public partial class MerchantServeCreate
    {
        #region Injects

        [Inject]
        private IMerchantServeService MerchantServeService { get; set; }

        #endregion Injects

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Model = new();

            if (UserGroupType != Business.UserGroupType.Admin)
            {
                if (UserServices.Count() == 1)
                {
                    MerchantServe merchantServe = MerchantServeService.GetById(UserServices.FirstOrDefault());
                    if (merchantServe != null)
                    {
                        Model.Merchant.Id = merchantServe.Merchant.Id;
                    }
                }
            }
        }

        #endregion Methods

        #region Properties

        public MerchantServeDto Model { get; set; }

        #endregion Properties
    }
}
