namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.MerchantServe
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;

    using Microsoft.AspNetCore.Components;

    public partial class MerchantServeEdit
    {
        #region Injects

        [Inject]
        private IMerchantServeService MerchantServeService { get; set; }

        #endregion Injects

        #region Parameters

        [Parameter]
        public int MerchantServeId { get; set; }

        #endregion Parameters

        #region Methods

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            Model = MerchantServeService.GetById<MerchantServeDto>(MerchantServeId);
        }

        #endregion Methods

        #region Properties

        public MerchantServeDto Model { get; set; }

        #endregion Properties
    }
}
