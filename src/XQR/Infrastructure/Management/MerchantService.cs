namespace Azox.XQR.Infrastructure
{
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Transactions;

    internal class MerchantService :
        EntityServiceBase<Merchant, MerchantService>,
        IMerchantService
    {
        #region Fields

        private readonly IMerchantServeService _merchantServeService;
        private readonly ILocationService _locationService;

        #endregion Fields

        #region Ctor

        public MerchantService(IServiceProvider serviceProvider) :
            base(serviceProvider)
        {
            _merchantServeService = serviceProvider.GetRequiredService<IMerchantServeService>();
            _locationService = serviceProvider.GetRequiredService<ILocationService>();
        }


        #endregion Ctor

        #region Methods

        public virtual async Task<Merchant> CreateAsync(string name, string description, MerchantType merchantType)
        {
            using (TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    Merchant merchant = new()
                    {
                        Name = name,
                        Description = description,
                        MerchantType = merchantType,
                        IsActive = true
                    };

                    await InsertAsync(merchant);

                    MerchantServe merchantServe = await _merchantServeService
                        .CreateAsync(merchant.Id, name, description, MerchantServeType.Restaurant);

                    await _locationService.CreateAsync(merchantServe.Id, name, description);

                    transaction.Complete();

                    return await GetByIdAsync(merchant.Id);
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex, ex.Message);
                    return null;
                }
            }
        }

        #endregion Methods
    }
}
