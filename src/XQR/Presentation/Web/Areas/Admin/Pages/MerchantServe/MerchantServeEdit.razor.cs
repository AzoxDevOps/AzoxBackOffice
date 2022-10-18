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

        [Inject]
        private NavigationManager Navigator { get; set; }

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
            bool allowEdit = UserServices.Contains(MerchantServeId) || UserGroupType == UserGroupType.Admin;

            if (!allowEdit || Model.IsDeleted)
            {
                Navigator.NavigateTo("/admin/service/list");
            }
        }

        #endregion Methods

        #region Properties

        public MerchantServeDto Model { get; set; }

        #endregion Properties
    }
}
