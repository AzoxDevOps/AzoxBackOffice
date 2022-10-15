namespace Azox.XQR.Infrastructure.Management.Eventing
{
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using System;
    using System.Threading.Tasks;

    internal class MerchantServeDeletedEventHandler :
        IEntityDeletedEventHandler<MerchantServe>
    {
        #region Fields

        private readonly ILogger<MerchantServeDeletedEventHandler> _logger;
        private readonly IServiceProvider _serviceProvider;

        #endregion Fields

        #region Ctor

        public MerchantServeDeletedEventHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _logger = serviceProvider.GetRequiredService<ILogger<MerchantServeDeletedEventHandler>>();
        }

        #endregion Ctor

        #region Methods

        public void Handle(MerchantServe obj)
        {
            try
            {
                if (obj == null)
                {
                    return;
                }

                ICategoryService categoryService = _serviceProvider
                    .GetRequiredService<ICategoryService>();

                ILocationService locationService = _serviceProvider
                    .GetRequiredService<ILocationService>();

                IEnumerable<Category> categories = categoryService.Filter(x => x.Service.Id == obj.Id);
                foreach (Category category in categories)
                {
                    categoryService.Delete(category);
                    _logger.LogInformation($"{category.Name} Silindi");
                }

                IEnumerable<Location> locations = locationService.Filter(x => x.Service.Id == obj.Id);
                foreach (Location location in locations)
                {
                    locationService.Delete(location);
                    _logger.LogInformation($"{location.Name} Silindi");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

        public async Task HandleAsync(MerchantServe obj)
        {
            await Task.CompletedTask;
        }

        #endregion Methods
    }
}
