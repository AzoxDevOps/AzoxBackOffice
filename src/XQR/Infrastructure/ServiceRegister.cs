namespace Azox.XQR.Infrastructure
{
    using Azox.Core.DependencyInjection;
    using Azox.XQR.Business;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    internal class ServiceRegister :
        IServiceRegister
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
