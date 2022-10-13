namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Merchant
{
    using Azox.XQR.Business.Dto;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;

    public partial class Detail_Main
    {
        #region Injects

        [Inject]
        private IWebHostEnvironment Environment { get; set; }

        [Inject]
        private ILogger<Detail_Main> Logger { get; set; }

        #endregion Injects

        #region Parameters

        [CascadingParameter]
        public MerchantDto Model { get; set; }

        #endregion Parameters

        #region Methods

        private async Task OnFileSelected(InputFileChangeEventArgs e)
        {
            try
            {
                string imageFileName = $"{Path.GetRandomFileName()}.{Path.GetExtension(e.File.Name)}";
                string imageFilePath = Path.Combine(Environment.WebRootPath, "dist", "images");
                string imageFullName = Path.Combine(imageFilePath, imageFileName);

                if (!Directory.Exists(imageFilePath))
                {
                    Directory.CreateDirectory(imageFilePath);
                }

                await using FileStream fs = new(imageFullName, FileMode.Create);
                await e.File.OpenReadStream().CopyToAsync(fs);

                Model.Picture.FileName = imageFileName;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
            }
        }

        #endregion Methods
    }
}
