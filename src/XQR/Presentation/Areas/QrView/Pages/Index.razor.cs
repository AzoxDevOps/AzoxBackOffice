namespace Azox.XQR.Presentation.Areas.QrView.Pages
{
    using Azox.XQR.Business;
    using Microsoft.AspNetCore.Components;
    using System.Threading.Tasks;

    public partial class Index
    {
        #region Injects

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
            base.OnInitialized();

            Parameters = new Dictionary<string, object>();
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            Location location = await LocationService
                .SingleOrDefaultAsync(x => x.Slug == LocationSlug);

            if (location != null)
            {
                ThemeType = Type.GetType(location.Service.ThemeTypeName);
                Parameters["LocationId"] = location.Id;
            }
        }

        #endregion Methods

        #region Properties

        private Type ThemeType { get; set; }

        private IDictionary<string, object> Parameters { get; set; }

        #endregion Properties
    }
}
