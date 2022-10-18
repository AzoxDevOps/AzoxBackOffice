namespace Azox.XQR.Presentation.Web.Areas.Admin.Components
{
    using Azox.Core.Extensions;
    using Azox.XQR.Business;

    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;

    using System.Text.Json;
    using System.Threading.Tasks;

    public partial class QrCode
    {
        #region Fields

        private string _id;

        #endregion Fields

        #region Injects

        [Inject]
        private IJSRuntime JsRuntime { get; set; }

        [Inject]
        private ILocationService LocationService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        #endregion Injects

        #region Parameters

        [Parameter]
        public int LocationId { get; set; }

        #endregion Parameters

        #region Methods

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                Location location = LocationService.GetById(LocationId);

                var qrGridOptions = new
                {
                    data = $"{Navigator.BaseUri}qr/{location.Slug}",
                    width = 80,
                    height = 80
                };

                await JsRuntime.InvokeVoidAsync("generateQrCode", Id, qrGridOptions);
            }
        }

        #endregion Methods

        #region Properties

        private string Id
        {
            get
            {
                if (_id.IsNullOrEmpty())
                {
                    _id = Convert.ToBase64String(Guid.NewGuid().ToByteArray())
                       .Replace("+", "-")
                       .Replace("/", "-")[..10];
                }

                return _id;
            }
        }

        #endregion Properties
    }
}
