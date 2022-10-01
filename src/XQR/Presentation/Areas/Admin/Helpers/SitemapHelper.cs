namespace Azox.XQR.Presentation.Areas.Admin.Helpers
{
    using System.Text.Json;

    internal class SitemapHelper
    {
        #region Fields

        private readonly IWebHostEnvironment _environment;
        private SitemapContext _sitemapContext;

        #endregion Fields

        #region Ctor

        public SitemapHelper(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        #endregion Ctor

        #region Utils

        private async Task<SitemapContext> GetSitemapContextAsync()
        {
            string sitemapPath = Path.Combine(_environment.ContentRootPath, "Areas", "Admin", "sitemap.json");
            using StreamReader reader = new(sitemapPath);
            string sitemapJson = await reader.ReadToEndAsync();

            return JsonSerializer.Deserialize<SitemapContext>(sitemapJson);
        }

        #endregion Utils

        #region Methods

        public async Task<SitemapContext> GetSitemapAsync()
        {
            if (_environment.IsDevelopment())
            {
                return await GetSitemapContextAsync();
            }
            else
            {
                _sitemapContext ??= await GetSitemapContextAsync();

                return _sitemapContext;
            }
        }

        #endregion Methods

        #region Nested

        public class SitemapContext
        {
            public SitemapItem[] Items { get; set; }

            public class SitemapItem
            {
                public string Name { get; set; }

                public string Url { get; set; }

                public SitemapItem[] Items { get; set; }
            }
        }

        #endregion Nested
    }
}
