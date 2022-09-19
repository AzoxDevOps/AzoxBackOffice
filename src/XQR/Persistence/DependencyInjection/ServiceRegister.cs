namespace Azox.XQR.Persistence.DependencyInjection
{
    using Azox.Core;
    using Azox.Core.DependencyInjection;
    using Azox.Persistence.Core;
    using Azox.XQR.Persistence.Configs;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    internal class ServiceRegister :
        IServiceRegister
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<XQRDbContext>((serviceProvider, options) =>
            {
                DbConfig dbConfig = serviceProvider.GetRequiredService<DbConfig>();

                switch (dbConfig.Provider)
                {
                    case DbProvider.MsSQL:
                        options.UseSqlServer(dbConfig.ConnectionString);
                        break;
                    case DbProvider.PostgreSQL:
                        options.UseNpgsql(dbConfig.ConnectionString);
                        break;
                    default:
                        throw new AzoxBugException("Invalid db provider");
                }

                //options.UseLazyLoadingProxies();
            });

            services.AddScoped<IDbContext, XQRDbContext>();
        }
    }
}
