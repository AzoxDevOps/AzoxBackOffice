namespace Azox.XQR.Presentation.Areas.Admin.Pages.Merchant
{
    using Azox.XQR.Business.Dto;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;

    public partial class _Info
    {
        #region Injects

        [Inject]
        private IWebHostEnvironment Environment { get; set; }

        #endregion Injects

        #region Methods

        private async Task OnChange(InputFileChangeEventArgs e)
        {
            try
            {
                string fileName = $"{Path.GetRandomFileName()}{Path.GetExtension(e.File.Name)}";
                string filePath = Path.Combine(Environment.WebRootPath, Environment.EnvironmentName, "images");
                string fullName = Path.Combine(filePath, fileName);

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                await using FileStream fs = new(Path.Combine(filePath, fileName), FileMode.Create);
                await e.File.OpenReadStream().CopyToAsync(fs);

                Model.Picture.FileName = Path.Combine(Environment.EnvironmentName, "images", fileName);
            }
            catch (Exception ex)
            {

            }
        }

        #endregion Methods

        #region Parameters

        [Parameter]
        public MerchantDto Model { get; set; }

        [Parameter]
        public bool IsNew { get; set; }

        #endregion Parameters
    }
}
