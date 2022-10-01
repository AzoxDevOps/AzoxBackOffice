namespace Azox.Infrastructure.Core
{
    using Azox.Business.Core.Domain.Concrete;
    using Azox.Business.Core.Service;
    using System;

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

        #endregion Methods
    }
}
