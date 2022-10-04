namespace Azox.XQR.Presentation.Areas.QrView.Themes.Material.Pages
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
        public int LocationId { get; set; }

        #endregion Parameters

        #region Methods

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

        }

        #endregion Methods

        #region Properties

        

        #endregion Properties
    }
}
