namespace Azox.XQR.Persistence.DependencyInjection
{
    using Azox.Core.DependencyInjection;
    using Azox.Persistence.Core;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    internal class ServiceRegister :
        IServiceRegister
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<XQRDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Postgres"));
            });

            services.AddScoped<IDbContext, XQRDbContext>();
        }
    }
}
