namespace Azox.XQR.Infrastructure
{
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;
    using System;

    internal class OrderItemService :
        EntityServiceBase<OrderItem, OrderItemService>,
        IOrderItemService
    {
        #region Ctor

        public OrderItemService(IServiceProvider serviceProvider) :
            base(serviceProvider)
        {
        }

        #endregion Ctor
    }
}
