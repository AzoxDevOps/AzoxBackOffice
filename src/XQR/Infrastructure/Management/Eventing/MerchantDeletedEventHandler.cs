namespace Azox.XQR.Infrastructure.Management.Eventing
{
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class MerchantDeletedEventHandler :
        IEntityDeletedEventHandler<Merchant>
    {
        #region Fields

        private readonly ILogger<MerchantDeletedEventHandler> _logger;
        private readonly IServiceProvider _serviceProvider;

        #endregion Fields

        #region Ctor

        public MerchantDeletedEventHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _logger = _serviceProvider.GetRequiredService<ILogger<MerchantDeletedEventHandler>>();
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

                IEnumerable<MerchantServe> merchantServes = merchantServeService
                    .Filter(x => x.Merchant.Id == obj.Id);

                foreach (MerchantServe merchantServe in merchantServes)
                {
                    merchantServeService.Delete(merchantServe);
                    _logger.LogInformation($"{merchantServe.Name} Silindi");
                }
            }
            catch (Exception ex)
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
