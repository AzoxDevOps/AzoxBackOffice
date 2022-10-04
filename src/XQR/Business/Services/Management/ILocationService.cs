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
        Task<Location> CreateAsync(int merchantServeId, string name, string description);
    }
}
