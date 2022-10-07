namespace Azox.XQR.Presentation.Web.Core.Services
{
    using Azox.XQR.Business;

    using Microsoft.AspNetCore.Components;

    using QRCoder;

    using System.Drawing.Imaging;

    internal class QrCodeGeneratorService :
        IQrCodeGeneratorService
    {
        #region Fields

        private readonly ILocationService _locationService;

        private readonly NavigationManager _navigationManager;

        #endregion Fields

        #region Ctor

        public QrCodeGeneratorService(
            NavigationManager navigationManager,
            IServiceScopeFactory serviceScopeFactory)
        {
            _navigationManager = navigationManager;
            _locationService = serviceScopeFactory.CreateAsyncScope().ServiceProvider.GetRequiredService<ILocationService>();
        }

        #endregion Ctor

        #region Methods

        public string GetQrCodeImage(int locationId)
        {
            Location location = _locationService.GetById(locationId);

            if (location != null)
            {
                string url = $"{_navigationManager.BaseUri}qr/{location.Slug}";

                QRCodeData qrCodeData = new QRCodeGenerator()
                    .CreateQrCode(new PayloadGenerator.Url(url));

                using MemoryStream ms = new();
                new QRCode(qrCodeData).GetGraphic(20).Save(ms, ImageFormat.Png);
                string imageData = Convert.ToBase64String(ms.ToArray());

                ms.Dispose();

                return $"data:image/png;base64, {imageData}";
            }

            return String.Empty;
        }

        #endregion Methods
    }
}
