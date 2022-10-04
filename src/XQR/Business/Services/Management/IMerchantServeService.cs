namespace Azox.XQR.Business
{
    using Azox.Business.Core.Service;

    /// <summary>
    /// 
    /// </summary>
    public interface IMerchantServeService :
        IEntityService<MerchantServe>
    {
        /// <summary>
        /// 
        /// </summary>
        Task<MerchantServe> CreateAsync(int merchantId, string name, string description, MerchantServeType serviceType);
    }
}
