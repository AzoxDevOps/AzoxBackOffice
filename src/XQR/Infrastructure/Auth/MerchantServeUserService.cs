namespace Azox.XQR.Infrastructure
{
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;
    using System;

    internal class MerchantServeUserService :
        EntityServiceBase<MerchantServeUser, MerchantServeUserService>,
        IMerchantServeUserService
    {
        #region Ctor

        public MerchantServeUserService(IServiceProvider serviceProvider) :
            base(serviceProvider)
        {

        }

        #endregion Ctor
    }
}
