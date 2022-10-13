namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Category
{
    using Azox.Core.Extensions;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Core.Localization;
    using Azox.XQR.Presentation.Web.Areas.Admin.Services;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using System;
    using System.Linq.Expressions;

    public partial class CategoryDetail
    {
        #region Injects

        [Inject]
        private IAuthService AuthService { get; set; }

        [Inject]
        private ICategoryService CategoryService { get; set; }

        [Inject]
        private ISelectListHelper SelectListHelper { get; set; }

        #endregion Injects

        #region Parameters

        [CascadingParameter]
        public CategoryDto Model { get; set; }

        #endregion Parameters

        #region Utils


        #endregion Utils

        #region Methods


        #endregion Methods

        #region Properties


        #endregion Properties
    }
}
