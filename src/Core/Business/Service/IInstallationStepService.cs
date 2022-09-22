namespace Azox.Business.Core.Service
{
    using Azox.Business.Core.Domain.Concrete;

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

        /// <summary>
        /// 
        /// </summary>
        void InsertStep(InstallationStep step);

        /// <summary>
        /// 
        /// </summary>
        void UpdateStep(InstallationStep step);
    }
}
