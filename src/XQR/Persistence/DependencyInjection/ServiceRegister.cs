namespace Azox.XQR.Persistence.DependencyInjection
{
    using Azox.Core.DependencyInjection;
    using Azox.Persistence.Core;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class ServiceRegister :
        IServiceRegister
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<XQRDbContext>(options =>
            {
                
            });

            services.AddScoped<IDbContext, XQRDbContext>();
        }
    }
}
