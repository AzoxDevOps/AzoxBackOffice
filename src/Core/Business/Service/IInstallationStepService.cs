namespace Azox.Business.Core.Service
{
    using Azox.Business.Core.Domain;

    /// <summary>
    /// 
    /// </summary>
    public interface IInstallationStepService :
        IEntityService<InstallationStep>
    {
        /// <summary>
        /// 
        /// </summary>
        InstallationStep GetStep(string stepName);
    }
}
