namespace Azox.XQR.Business
{
    using Azox.Business.Core.Service;

    /// <summary>
    /// 
    /// </summary>
    public interface IMerchantService :
        IEntityService<Merchant>
    {
        /// <summary>
        /// 
        /// </summary>
        Task<Merchant> CreateAsync(string name, string description, MerchantType merchantType);
    }
}
