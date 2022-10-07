namespace Azox.XQR.Presentation.Web.Areas.Admin.Shared
{
    using Azox.XQR.Presentation.Web.Areas.Admin.Helpers;

    using Microsoft.AspNetCore.Components;

    public partial class AdminTopMenu
    {
        #region Injects

        [Inject]
        private SitemapHelper SitemapHelper { get; set; }

        #endregion Injects

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Sitemap = await SitemapHelper.GetSitemapAsync();
        }

        #endregion Methods

        #region Properties

        internal SitemapHelper.SitemapContext Sitemap { get; set; }

        #endregion Properties
    }
}
