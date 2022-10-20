namespace Azox.XQR.Business.Dto
{
    using Azox.Business.Core.Dto;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OrderDto:
        DeletableTrackableDtoBase<Order,long>
    {
        #region Ctor

        public OrderDto()
        {
            Location = new();
        }

        #endregion Ctor

        #region Methods

        public override void Init(Order entity)
        {
            base.Init(entity);

            if (entity.Location!= null)
            {
                Location.Init(entity.Location);
            }
        }

        #endregion Methods

        #region Properties

        public LocationDto Location { get; set; }

        #endregion Properties
    }
}
