namespace Azox.Core.DependencyInjection
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// 
    /// </summary>
    public interface IServiceRegister
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        void Register(IServiceCollection services, IConfiguration configuration);
    }
}
