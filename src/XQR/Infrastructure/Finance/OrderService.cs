namespace Azox.XQR.Infrastructure
{
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;
    using System;

    internal class OrderService :
        EntityServiceBase<Order, OrderService>,
        IOrderService
    {
        #region Ctor

        public OrderService(IServiceProvider serviceProvider) :
            base(serviceProvider)
        {
        }

        #endregion Ctor
    }
}
