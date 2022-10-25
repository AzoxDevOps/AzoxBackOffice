namespace Azox.XQR.Infrastructure
{
    using Azox.Core;
    using Azox.Core.Extensions;
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;

    using Microsoft.Extensions.DependencyInjection;

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

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        public Location Create(int merchantServeId, string name)
        {
            IMerchantServeService merchantServeService = ServiceProvider
                .GetRequiredService<IMerchantServeService>();

            MerchantServe merchantServe = merchantServeService
                .GetById(merchantServeId);

            if (merchantServe == null)
            {
                throw new AzoxBugException();
            }

            Location location = new()
            {
                Service = merchantServe,
                Name = name,
                IsActive = true,
                Slug = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("+", "-").Replace("/", "-")[..10]
            };

            Insert(location);
            return GetById(location.Id);
        }

        #endregion Methods
    }
}
