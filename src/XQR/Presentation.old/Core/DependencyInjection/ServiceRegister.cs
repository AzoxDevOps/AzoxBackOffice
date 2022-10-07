﻿namespace Azox.XQR.Presentation.Web.Core.DependencyInjection
{
    using Azox.Core.DependencyInjection;
    using Azox.XQR.Presentation.Web.Core.Services;

    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    internal class ServiceRegister :
        IServiceRegister
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IInstallationService, InstallationService>();

            services.AddScoped<ILocalStorageService, LocalStorageService>();
            services.AddScoped<AuthenticationStateProvider, LoginService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IQrCodeGeneratorService, QrCodeGeneratorService>();
        }
    }
}