namespace Azox.Toolkit.Blazor.DependencyInjection
{
    using Azox.Core.DependencyInjection;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    internal class ServiceRegister :
        IServiceRegister
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IToastService, ToastService>();
        }
    }
}
