namespace Azox.XQR.Presentation.Web.Pages
{
    using Azox.XQR.Business;
    using Azox.XQR.Presentation.Core.Themes;

    using Microsoft.AspNetCore.Components;

    public partial class QrMenu
    {
        #region Injects

        [Inject]
        private IThemeContext ThemeContext { get; set; }

        [Inject]
        private ILocationService LocationService { get; set; }

        #endregion Injects

        #region Parameters

        [Parameter]
        public string LocationSlug { get; set; }

        #endregion Parameters

        #region Methods

        protected override void OnInitialized()
        {
            if (!LocationService.GetThemeTypeName(LocationSlug, out string themeTypeName))
            {
                return;
            }

            ThemeComponentType = ThemeContext.GetThemeMainComponentType(themeTypeName);
        }

        #endregion Methods

        #region Properties

        private Type ThemeComponentType { get; set; }

        #endregion Properties
    }
}
