namespace Azox.Core.DependencyInjection
{
    using Azox.Core.Eventing;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    internal class ServiceRegister :
        IServiceRegister
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IEventHandlerService, EventHandlerService>();
        }
    }
}
