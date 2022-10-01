namespace Azox.XQR.Business.Dto.Management
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

            if (entity.Service != null)
            {
                Service.Init(entity.Service);
            }
        }

        #endregion Methods

        #region Properties

        public MerchantServeDto Service { get; set; }

        #endregion Properties
    }
}
