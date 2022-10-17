namespace Azox.XQR.Infrastructure.Management.Eventing
{
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;

    using Microsoft.Extensions.DependencyInjection;

    using System;
    using System.Threading.Tasks;

    internal class MerchantServeInsertedEventHandler :
        IEntityInsertedEventHandler<MerchantServe>
    {
        #region Fields

        private readonly IServiceProvider _serviceProvider;

        #endregion Fields

        #region Ctor

        public MerchantServeInsertedEventHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        #endregion Ctor

        #region Methods

        public void Handle(MerchantServe obj)
        {
            if (obj == null)
            {
                return;
            }

            ILocationService locationService = _serviceProvider
                .GetRequiredService<ILocationService>();

            locationService.Create(obj.Id, obj.Name);
        }

        public async Task HandleAsync(MerchantServe obj)
        {
            await Task.CompletedTask;
        }

        #endregion Methods
    }
}
