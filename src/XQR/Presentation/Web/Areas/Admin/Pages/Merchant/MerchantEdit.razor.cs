namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Merchant
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;

    using Microsoft.AspNetCore.Components;

    public partial class MerchantEdit
    {
        #region Injects

        [Inject]
        private IMerchantService MerchantService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        #endregion

        #region Parameters

        [Parameter]
        public int MerchantId { get; set; }

        #endregion Parameters

        #region Methods

        protected override void OnParametersSet()
        {
            base.OnInitialized();
            Model = MerchantService.GetById<MerchantDto>(MerchantId);

            if (Model.IsDeleted)
            {
                Navigator.NavigateTo("/admin/merchant/list");
            }
        }

        #endregion Methods

        #region Properties

        public MerchantDto Model { get; set; }

        #endregion Properties
    }
}
