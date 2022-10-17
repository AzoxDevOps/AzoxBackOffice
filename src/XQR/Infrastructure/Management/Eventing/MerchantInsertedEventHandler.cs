namespace Azox.XQR.Infrastructure.Management.Eventing
{
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using System;
    using System.Threading.Tasks;

    internal class MerchantInsertedEventHandler :
        IEntityInsertedEventHandler<Merchant>
    {
        #region Fields

        private readonly ILogger<MerchantInsertedEventHandler> _logger;
        private readonly IServiceProvider _serviceProvider;

        #endregion Fields

        #region Ctor

        public MerchantInsertedEventHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _logger= _serviceProvider.GetRequiredService<ILogger<MerchantInsertedEventHandler>>();
        }

        #endregion Ctor

        #region Methods

        public void Handle(Merchant obj)
        {
            try
            {
                if (obj == null)
                {
                    return;
                }

                IMerchantServeService merchantServeService = _serviceProvider
                    .GetRequiredService<IMerchantServeService>();

                merchantServeService.Create(obj.Id, obj.Name, obj.Description, MerchantServeType.Restaurant);

                _logger.LogInformation($"{obj.Name} Eklendi");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

        public async Task HandleAsync(Merchant obj)
        {
            await Task.CompletedTask;
        }

        #endregion Methods
    }
}
