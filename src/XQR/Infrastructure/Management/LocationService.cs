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

        public bool GetThemeTypeName(string slug, out string themeTypeName)
        {
            themeTypeName = string.Empty;

            if (slug.IsNullOrEmpty())
            {
                return false;
            }

            Location location = SingleOrDefault(x => x.Slug == slug);
            if (location == null)
            {
                return false;
            }

            themeTypeName = location.Service.ThemeTypeName;
            return true;
        }

        public void SetAsActive(int locationId)
        {
            Location location = GetById(locationId);
            if (location != null)
            {
                location.IsActive = true;
                Update(location);
            }
        }

        public void SetAsPassive(int locationId)
        {
            Location location = GetById(locationId);
            if (location != null)
            {
                location.IsActive = false;
                Update(location);
            }
        }

        #endregion Methods
    }
}
