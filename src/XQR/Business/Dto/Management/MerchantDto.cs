namespace Azox.XQR.Business.Dto
{
    using Azox.Business.Core.Dto;

    /// <summary>
    /// 
    /// </summary>
    public class MerchantDto :
        DeletableBasicDtoBase<Merchant>
    {
        #region Ctor

        public MerchantDto()
        {
            Address = new();
            Contact = new();
            Picture = new();
        }

        #endregion Ctor

        #region Methods

        public override void Init(Merchant entity)
        {
            base.Init(entity);

            MerchantType = entity.MerchantType;
            FacebookLink = entity.FacebookLink;
            InstagramLink = entity.InstagramLink;
            IsActive = entity.IsActive;

            if (entity.Address != null)
            {
                Address = new(entity.Address.City, entity.Address.District, entity.Address.AddressLine, entity.Address.Latitude, entity.Address.Longitude);
            }

            if (entity.Contact != null)
            {
                Contact = new(entity.Contact.Name, entity.Contact.Phone, entity.Contact.Email);
            }

            if (entity.Picture != null)
            {
                Picture = new(entity.Picture.FileName);
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
        public MerchantType MerchantType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Contact Contact { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Picture Picture { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FacebookLink { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string InstagramLink { get; set; }

        #endregion Properties
    }
}
