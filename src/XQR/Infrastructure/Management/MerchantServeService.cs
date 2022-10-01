namespace Azox.XQR.Infrastructure.Management
{
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;
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
    }
}
