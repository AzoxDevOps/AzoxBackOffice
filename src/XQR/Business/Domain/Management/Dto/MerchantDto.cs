namespace Azox.XQR.Business.Domain.Management
{
    using Azox.Business.Core.Domain.Dto;

    /// <summary>
    /// 
    /// </summary>
    public class MerchantDto :
        BasicEntityBaseDto<Merchant>
    {
        #region Ctor

        public MerchantDto() : base()
        {

        }

        public MerchantDto(Merchant merchant) :
            base(merchant)
        {

        }

        #endregion Ctor

        #region Properties

        public MerchantType MerchantType { get; set; }

        #endregion Properties
    }
}
