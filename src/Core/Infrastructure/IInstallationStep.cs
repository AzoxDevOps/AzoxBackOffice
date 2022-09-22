namespace Azox.Infrastructure.Core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IInstallationStep
    {
        /// <summary>
        /// 
        /// </summary>
        void Install(IServiceProvider serviceProvider);
    }
}
