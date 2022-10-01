namespace Azox.XQR.Presentation.Services
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
    internal class InstallationService
    {
        #region Fields

        private static readonly object _installLockObject = new();

        private readonly ILogger _logger;
        private readonly IDbContext _dbContext;
        private readonly ITypeFinder _typeFinder;
        private readonly IInstallationStepService _installationStepService;

        private readonly IServiceProvider _serviceProvider;

        #endregion Fields

        #region Ctor

        public InstallationService(
            IServiceScopeFactory serviceScopeFactory)
        {
            _serviceProvider = serviceScopeFactory.CreateScope().ServiceProvider;

            _logger = _serviceProvider.GetRequiredService<ILogger<InstallationService>>();
            _dbContext = _serviceProvider.GetRequiredService<IDbContext>();
            _typeFinder = _serviceProvider.GetRequiredService<ITypeFinder>();
            _installationStepService = _serviceProvider.GetRequiredService<IInstallationStepService>();
        }

        #endregion Ctor

        #region Methods

        public void Install()
        {
            lock (_installLockObject)
            {
                if (Installed)
                {
                    return;
                }
                try
                {
                    _dbContext.Database.Migrate();

                    foreach (IInstallationStep step in _typeFinder.FindInstancesOf<IInstallationStep>())
                    {
                        string stepName = step.GetType().FullName;

                        InstallationStep installationStep = _installationStepService.GetStep(stepName)
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

                        _installationStepService.UpdateStep(installationStep);
                        _dbContext.SaveChanges();
                    }

                    Installed = true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
            }
        }

        #endregion Methods

        #region Properties

        public bool Installed { get; private set; }

        #endregion Properties
    }
}
