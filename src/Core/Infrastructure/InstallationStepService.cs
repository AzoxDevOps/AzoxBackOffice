namespace Azox.Infrastructure.Core
{
    using Azox.Business.Core.Domain.Concrete;
    using Azox.Business.Core.Service;
    using System;
    using System.Threading.Tasks;

    internal class InstallationStepService :
        EntityServiceBase<InstallationStep, InstallationStepService>,
        IInstallationStepService
    {
        #region Ctor

        public InstallationStepService(IServiceProvider serviceProvider) :
            base(serviceProvider)
        {

        }

        #endregion Ctor

        #region Methods

        public InstallationStep GetStep(string stepName)
        {
            InstallationStep step = Repository
                .SingleOrDefault(x => x.StepName == stepName);

            return step;
        }

        public void InsertStep(InstallationStep step)
        {
            Repository.Insert(step);
        }

        public void UpdateStep(InstallationStep step)
        {
            Repository.Update(step);
        }

        #endregion Methods
    }
}
