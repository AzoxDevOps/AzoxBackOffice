namespace Azox.XQR.Infrastructure.Management
{
    using Azox.Core;
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;

    using Microsoft.Extensions.DependencyInjection;

    using System;

    internal class MerchantServeService :
        EntityServiceBase<MerchantServe, MerchantServeService>,
        IMerchantServeService
    {
        #region Ctor

        public MerchantServeService(IServiceProvider serviceProvider) :
            base(serviceProvider)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        public MerchantServe Create(int merchantId, string name, string description, MerchantServeType serviceType)
        {
            IMerchantService merchantService = ServiceProvider
                .GetRequiredService<IMerchantService>();

            Merchant merchant = merchantService.GetById(merchantId);
            if (merchant == null)
            {
                throw new AzoxBugException();
            }

            MerchantServe merchantServe = new()
            {
                Merchant = merchant,
                Name = name,
                Description = description,
                ServiceType = serviceType,
                IsActive = true
            };

            Insert(merchantServe);
            return GetById(merchantServe.Id);
        }

        #endregion Methods
    }
}
