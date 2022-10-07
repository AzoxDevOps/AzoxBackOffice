namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Merchant
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;

    using Microsoft.AspNetCore.Components;

    public partial class Edit
    {
        #region Injects

        [Inject]
        private IMerchantService MerchantService { get; set; }

        #endregion Injects

        #region Parameters

        [Parameter]
        public int Id { get; set; }

        #endregion Parameters

        #region Methods

        protected override void OnInitialized()
        {
            Model = MerchantService.GetById<MerchantDto>(Id);
        }

        #endregion Methods

        #region Properties

        private MerchantDto Model { get; set; }

        #endregion Properties
    }
}
