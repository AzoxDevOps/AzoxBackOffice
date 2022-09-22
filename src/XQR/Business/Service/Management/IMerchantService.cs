namespace Azox.XQR.Business.Service.Management
{
    using Azox.Business.Core.Service;
    using Azox.XQR.Business.Domain.Management;

    /// <summary>
    /// 
    /// </summary>
    public interface IMerchantService :
        IEntityService<Merchant>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Merchant>> GetAllMerchantsAsync();
    }
}
