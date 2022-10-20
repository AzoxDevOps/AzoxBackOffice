namespace Azox.XQR.Business.Dto
{
    using Azox.Business.Core.Dto;

    /// <summary>
    /// 
    /// </summary>
    public class MerchantServeDto :
        DeletableBasicDtoBase<MerchantServe>
    {
        #region Ctor

        public MerchantServeDto()
        {
            Merchant = new();
            Contacts = new();
            WorkingHours = new();

            ServiceType = MerchantServeType.Restaurant;
        }

        #endregion Ctor

        #region Methods

        public override void Init(MerchantServe entity)
        {
            base.Init(entity);

            IsActive = entity.IsActive;
            Currency = entity.Currency;
            ServiceType = entity.ServiceType;
            ThemeTypeName = entity.ThemeTypeName;

            if (entity.Merchant != null)
            {
                Merchant.Init(entity.Merchant);
            }

            if (entity.Contacts != null)
            {
                Contacts.AddRange(entity.Contacts);
            }

            if (entity.WorkingHours != null)
            {
                WorkingHours.AddRange(entity.WorkingHours);
            }
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Currency Currency { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MerchantDto Merchant { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MerchantServeType ServiceType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? ThemeTypeName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual List<Contact> Contacts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual List<MerchantServeWorkingHour> WorkingHours { get; set; }

        #endregion Properties
    }
}
