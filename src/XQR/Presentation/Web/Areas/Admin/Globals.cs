namespace Azox.XQR.Presentation.Web.Areas.Admin
{
    public class Globals
    {
        /// <summary>
        /// 
        /// </summary>
        public static int DefaultGridPageSize => 10;

        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<int> GridPageSizes =>
            new List<int> { 5, 10, 20, 50, 100 };
    }
}
