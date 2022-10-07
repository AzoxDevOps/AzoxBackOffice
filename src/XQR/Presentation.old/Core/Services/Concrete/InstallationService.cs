namespace Azox.XQR.Presentation.Web.Core.Services
{
    using Azox.Business.Core.Domain.Concrete;
    using Azox.Business.Core.Service;
    using Azox.Core.Reflection;
    using Azox.Infrastructure.Core;
    using Azox.Persistence.Core;
    
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// 
    /// </summary>
    internal class InstallationService :
        IInstallationService
    {
        #region Fields

        private readonly object _lock = new object();
        private readonly IServiceProvider _serviceProvider;

        private bool _installed;

        #endregion Fields

        #region Ctor

        public InstallationService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceProvider = serviceScopeFactory.CreateScope().ServiceProvider;
        }

        #endregion Ctor

        #region Methods

        public void Install()
        {
            lock (_lock)
            {
                if (_installed)
                {
                    return;
                }

                try
                {
                    DbContext.Database.Migrate();

                    foreach (IInstallationStep step in TypeFinder.FindInstancesOf<IInstallationStep>().OrderBy(x => x.Priority))
                    {
                        string stepName = step.GetType().FullName;

                        InstallationStep installationStep = StepService.GetStep(stepName)
                            ?? new InstallationStep { StepName = stepName };

                        if (installationStep.Success)
                        {
                            continue;
                        }

                        try
                        {
                            step.Install(_serviceProvider);

                            installationStep.Success = true;
                            installationStep.LastExecutionTime = DateTime.Now;
                        }
                        catch (Exception ex)
                        {
                            installationStep.Success = false;
                            installationStep.Error = ex.Message;
                        }

                        if (installationStep.Id == 0)
                        {
                            StepService.Insert(installationStep);
                        }
                        else
                        {
                            StepService.Update(installationStep);
                        }

                        DbContext.SaveChanges();
                    }

                    _installed = true;
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex, ex.Message);
                }
            }
        }

        #endregion Methods

        #region Properties

        private IDbContext DbContext => _serviceProvider.GetRequiredService<IDbContext>();

        private IInstallationStepService StepService => _serviceProvider.GetRequiredService<IInstallationStepService>();

        private ILogger Logger => _serviceProvider.GetRequiredService<ILogger<InstallationService>>();

        private ITypeFinder TypeFinder => _serviceProvider.GetRequiredService<ITypeFinder>();

        #endregion Properties
    }
}
