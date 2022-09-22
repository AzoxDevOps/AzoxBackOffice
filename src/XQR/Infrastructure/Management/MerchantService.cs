namespace Azox.XQR.Infrastructure.Management
{
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business.Domain.Management;
    using Azox.XQR.Business.Service.Management;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class MerchantService :
        EntityServiceBase<Merchant, MerchantService>,
        IMerchantService
    {
        #region Ctor

        public MerchantService(IServiceProvider serviceProvider) :
            base(serviceProvider)
        {

        }


        #endregion Ctor

        #region Methods


        public async Task<IEnumerable<Merchant>> GetAllMerchantsAsync()
        {
            return await Repository.FilterAsync(x => !x.IsDeleted);
        }

        #endregion Methods
    }
}
