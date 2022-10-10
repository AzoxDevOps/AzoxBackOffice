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

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        public Merchant Create(string name, string description, MerchantType merchantType)
        {
            Merchant merchant = new()
            {
                Name = name,
                Description = description,
                MerchantType = merchantType,
                IsActive = true
            };

            Insert(merchant);

            return GetById(merchant.Id);
        }

        #endregion Methods
    }
}
