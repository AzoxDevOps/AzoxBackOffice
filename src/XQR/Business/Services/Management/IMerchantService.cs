namespace Azox.XQR.Business
{
    using Azox.Business.Core.Service;
    using Azox.XQR.Business.Dto;

    /// <summary>
    /// 
    /// </summary>
    public interface IMerchantService :
        IEntityService<Merchant>
    {
        /// <summary>
        /// 
        /// </summary>
        Merchant Create(string name, string description, MerchantType merchantType);
    }
}
