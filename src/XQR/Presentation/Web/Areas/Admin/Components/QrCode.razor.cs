namespace Azox.XQR.Presentation.Web.Areas.Admin.Components
{
    using Azox.Core.Extensions;
    using Azox.XQR.Business;

    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;

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

        [Parameter]
        public int Width { get; set; }

        [Parameter]
        public int Height { get; set; }

        [Parameter]
        public bool Magnifable { get; set; }

        #endregion Parameters

        #region Methods

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Location location = LocationService.GetById(LocationId);
            Href = $"{Navigator.BaseUri}qr/{location.Slug}";
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            
            if (firstRender)
            {
                Location location = LocationService.GetById(LocationId);

                var qrGridOptions = new
                {
                    data = $"{Navigator.BaseUri}qr/{location.Slug}",
                    width = Width,
                    height = Height
                };

                Href = qrGridOptions.data;
                await JsRuntime.InvokeVoidAsync("generateQrCode", Id, qrGridOptions);
            }
        }

        private async Task OnClick()
        {
            if (!Magnifable)
            {
                return;
            }

            if (!RenderMagnified)
            {
                Location location = LocationService.GetById(LocationId);

                var qrGridOptions = new
                {
                    data = $"{Navigator.BaseUri}qr/{location.Slug}",
                    width = 300,
                    height = 300
                };
                await JsRuntime.InvokeVoidAsync("generateQrCode", $"fs-{Id}", qrGridOptions);
                RenderMagnified = true;
            }

            ShowMagnified = true;
        }

        private void OnClose()
        {
            ShowMagnified = false;
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

        private string Href { get; set; }

        private bool RenderMagnified { get; set; }

        private bool ShowMagnified { get; set; }

        #endregion Properties
    }
}
