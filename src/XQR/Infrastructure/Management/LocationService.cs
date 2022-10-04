namespace Azox.XQR.Infrastructure
{
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;
    using System;
    using System.Transactions;

    internal class LocationService :
        EntityServiceBase<Location, LocationService>,
        ILocationService
    {
        #region Fields

        private readonly IMerchantServeService _merchantServeService;

        #endregion Fields

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
        public virtual async Task<Location> CreateAsync(int merchantServeId, string name, string description)
        {
            using (TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled))
            {
                MerchantServe merchantServe = await _merchantServeService.GetByIdAsync(merchantServeId);

                Location location = new()
                {
                    Service = merchantServe,
                    Name = name,
                    Description = description
                };

                await InsertAsync(location);
                transactionScope.Complete();

                return await GetByIdAsync(location.Id);
            }
        }

        #endregion Methods
    }
}
