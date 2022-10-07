namespace Azox.XQR.Infrastructure
{
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;

    using System;

    internal class LocationService :
        EntityServiceBase<Location, LocationService>,
        ILocationService
    {
        #region Ctor

        public LocationService(IServiceProvider serviceProvider) :
            base(serviceProvider)
        {
        }

        #endregion Ctor
    }
}
