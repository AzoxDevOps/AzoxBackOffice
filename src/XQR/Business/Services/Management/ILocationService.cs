namespace Azox.XQR.Business
{
    using Azox.Business.Core.Service;

    /// <summary>
    /// 
    /// </summary>
    public interface ILocationService :
        IEntityService<Location>
    {
        /// <summary>
        /// 
        /// </summary>
        Location Create(int merchantServeId, string name);

        /// <summary>
        /// 
        /// </summary>
        bool GetThemeTypeName(string slug, out string themeTypeName);
    }
}
