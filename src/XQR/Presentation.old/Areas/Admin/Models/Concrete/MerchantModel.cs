namespace Azox.XQR.Presentation.Areas.Admin.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class MerchantModel :
        BasicEntityModelBase<Merchant>
    {
        #region Ctor

        public MerchantModel()
        {
            Contact = new();
        }

        public MerchantModel(Merchant merchant) :
            base(merchant)
        {
            MerchantType = merchant.MerchantType;
            Contact = merchant.Contact;
        }

        #endregion Ctor

        #region Properties

        public MerchantType MerchantType { get; set; }

        public Contact Contact { get; set; }

        #endregion Properties
    }
}
