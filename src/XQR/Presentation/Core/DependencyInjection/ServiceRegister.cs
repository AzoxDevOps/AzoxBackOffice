namespace Azox.XQR.Presentation.Core.DependencyInjection
{
    using Azox.Core.DependencyInjection;
    using Azox.XQR.Presentation.Core.Themes;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    internal class ServiceRegister :
        IServiceRegister
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IThemeContext, ThemeContext>();
        }
    }
}
