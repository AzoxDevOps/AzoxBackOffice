namespace Azox.Persistence.Core.DependencyInjection
{
    using Azox.Business.Core.Data;
    using Azox.Core.DependencyInjection;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    internal class ServiceRegister :
        IServiceRegister
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }
    }
}
