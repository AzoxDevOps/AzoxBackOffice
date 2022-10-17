﻿namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.MerchantServe
{
    using Azox.XQR.Business.Dto;

    public partial class MerchantServeCreate
    {
        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Model = new();
        }

        #endregion Methods

        #region Properties

        public MerchantServeDto Model { get; set; }

        #endregion Properties
    }
}