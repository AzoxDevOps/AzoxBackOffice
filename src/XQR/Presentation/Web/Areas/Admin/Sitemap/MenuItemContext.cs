namespace Azox.XQR.Presentation.Web.Areas.Admin.Sitemap
{
    public class MenuItemContext
    {
        #region Properties

        public List<MenuItem> Items { get; set; }

        #endregion Properties

        #region Nested

        /// <summary>
        /// 
        /// </summary>
        public class MenuItem
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
            public List<MenuItem> Items { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public int[] Roles { get; set; }
        }

        #endregion Nested
    }
}
