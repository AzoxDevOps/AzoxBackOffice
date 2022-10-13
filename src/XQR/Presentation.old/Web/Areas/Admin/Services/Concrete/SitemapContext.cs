namespace Azox.XQR.Presentation.Web.Areas.Admin.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class SitemapContext
    {
        #region Properties

        public SitemapItem[] Items { get; set; }

        #endregion Properties

        #region Nested

        /// <summary>
        /// 
        /// </summary>
        public class SitemapItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string Icon { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string Url { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public SitemapItem[] Items { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public int[] Roles { get; set; }
        }

        #endregion Nested
    }
}