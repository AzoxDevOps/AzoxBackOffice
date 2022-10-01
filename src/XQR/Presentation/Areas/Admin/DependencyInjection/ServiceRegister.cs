﻿namespace Azox.XQR.Presentation.Areas.Admin.DependencyInjection
{
    using Azox.Core.DependencyInjection;
    using Azox.XQR.Presentation.Areas.Admin.Helpers;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    internal class ServiceRegister :
        IServiceRegister
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<SitemapHelper>();
        }
    }
}
