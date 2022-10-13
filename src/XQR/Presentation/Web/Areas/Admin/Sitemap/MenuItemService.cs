namespace Azox.XQR.Presentation.Web.Areas.Admin.Sitemap
{
    using System.Text.Json;

    /// <summary>
    /// 
    /// </summary>
    internal class MenuItemService
    {
        #region Fields

        private readonly IWebHostEnvironment _environment;
        private MenuItemContext _sitemapContext;
        #endregion Fields

        #region Ctor

        public MenuItemService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        #endregion Ctor

        #region Utils

        private async Task<MenuItemContext> ReadMenuItemConfigFile()
        {
            string sitemapPath = Path.Combine(_environment.ContentRootPath, "Areas", "Admin", "Sitemap","sitemap.json");
            using StreamReader reader = new(sitemapPath);
            string sitemapContent = await reader.ReadToEndAsync();

            reader.Close();
            return JsonSerializer.Deserialize<MenuItemContext>(sitemapContent);
        }

        #endregion Utils

        #region Methods

        public async Task<MenuItemContext> GetMenuItemContext()
        {
            if (_environment.IsDevelopment())
            {
                return await ReadMenuItemConfigFile();
            }

            _sitemapContext ??= await ReadMenuItemConfigFile();

            return _sitemapContext;
        }

        #endregion Methods
    }
}
