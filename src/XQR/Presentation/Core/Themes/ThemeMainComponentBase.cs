namespace Azox.XQR.Presentation.Core.Themes
{
    using Azox.XQR.Business;

    using Microsoft.AspNetCore.Components;

    public abstract class ThemeMainComponentBase :
        LayoutComponentBase,
        IThemeMainComponent
    {
        #region Injects

        [Inject]
        private ILocationService LocationService { get; set; }

        [Inject]
        private NavigationManager Navigation { get; set; }

        #endregion Injects

        #region Parameters

        [Parameter]
        public string LocationSlug { get; set; }

        #endregion Parameters

        #region Methods

        protected override void OnParametersSet()
        {
            Location location = LocationService.SingleOrDefault(x=>x.Slug == LocationSlug);
            ServiceName = location.Service.Name;
        }

        protected void GotoHome()
        {
            Navigation.NavigateTo($"/qr/{LocationSlug}");
        }

        #endregion Methods

        #region Properties

        protected string ServiceName { get; set; }

        #endregion Properties
    }
}
