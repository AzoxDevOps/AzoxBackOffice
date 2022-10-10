namespace Azox.Core.Extensions
{
    using Azox.Core.Configs;
    using Azox.Core.DependencyInjection;
    using Azox.Core.Reflection;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// 
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void RegisterServices(
            this IServiceCollection services,
            IConfiguration configuration,
            params string[] externalPaths)
        {
            TypeFinder typeFinder = new();

            typeFinder.AddDirectoryPaths(externalPaths);

            IEnumerable<IServiceRegister> serviceRegisters = typeFinder
                .FindInstancesOf<IServiceRegister>();

            services.AddSingleton<ITypeFinder>(typeFinder);

            foreach (IServiceRegister serviceRegister in serviceRegisters)
            {
                serviceRegister.Register(services, configuration);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void RegisterConfigs(
            this IServiceCollection services,
            IConfiguration configuration,
            params string[] externalPaths)
        {
            TypeFinder typeFinder = new();

            typeFinder.AddDirectoryPaths(externalPaths);

            IEnumerable<IConfig> configs = typeFinder
                .FindInstancesOf<IConfig>();

            foreach (IConfig config in configs)
            {
                configuration.GetSection(config.ConfigName)
                    .Bind(config);

                services.AddSingleton(config.GetType(), config);
            }
        }
    }
}
