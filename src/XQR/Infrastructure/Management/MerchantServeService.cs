namespace Azox.XQR.Infrastructure.Management
{
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Transactions;

    internal class MerchantServeService :
        EntityServiceBase<MerchantServe, MerchantServeService>,
        IMerchantServeService
    {
        #region Fields

        private readonly IMerchantService _merchantService;

        #endregion Fields

        #region Ctor

        public MerchantServeService(IServiceProvider serviceProvider) :
            base(serviceProvider)
        {
            _merchantService = serviceProvider.GetRequiredService<IMerchantService>();
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<MerchantServe> CreateAsync(int merchantId, string name, string description, MerchantServeType serviceType)
        {
            using (TransactionScope transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                Merchant merchant = await _merchantService.GetByIdAsync(merchantId);

                MerchantServe service = new()
                {
                    Merchant = merchant,
                    Name = name,
                    Description = description,
                    ServiceType = serviceType
                };

                await InsertAsync(service);
                transaction.Complete();

                return await GetByIdAsync(service.Id);
            }
        }

        #endregion Methods
    }
}
