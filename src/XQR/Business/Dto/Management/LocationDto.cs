namespace Azox.XQR.Business.Dto
{
    using Azox.Business.Core.Dto;

    public class LocationDto :
        DeletableBasicDtoBase<Location>
    {
        #region Ctor

        public LocationDto()
        {
            Service = new();
        }

        #endregion Ctor

        #region Methods

        public override void Init(Location entity)
        {
            base.Init(entity);

            IsActive = entity.IsActive;
            Slug = entity.Slug;

            if (entity.Service != null)
            {
                Service.Init(entity.Service);
            }
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public MerchantServeDto Service { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Slug { get; set; }

        #endregion Properties
    }
}
