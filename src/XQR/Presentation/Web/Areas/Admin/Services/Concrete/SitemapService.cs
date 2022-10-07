namespace Azox.XQR.Presentation.Web.Areas.Admin.Services
{
    using System.Text.Json;

    internal class SitemapService :
        ISitemapService
    {
        #region Fields

        private readonly IWebHostEnvironment _environment;
        private SitemapContext _sitemapContext;
        #endregion Fields

        #region Ctor

        public SitemapService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        #endregion Ctor

        #region Utils

        private async Task<SitemapContext> GetSitemapContextAsync()
        {
            string sitemapPath = Path.Combine(_environment.ContentRootPath, "Areas", "Admin", "sitemap.json");
            using StreamReader reader = new(sitemapPath);
            string sitemapContent = await reader.ReadToEndAsync();

            reader.Close();
            return JsonSerializer.Deserialize<SitemapContext>(sitemapContent);
        }

        #endregion Utils

        #region Methods

        public async Task<SitemapContext> GetSitemapContext()
        {
            if (_environment.IsDevelopment())
            {
                return await GetSitemapContextAsync();
            }

            _sitemapContext ??= await GetSitemapContextAsync();

            return _sitemapContext;
        }

        #endregion Methods
    }
}
