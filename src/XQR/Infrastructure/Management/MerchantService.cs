namespace Azox.XQR.Infrastructure
{
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;

    using System;

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
    }
}
