namespace Azox.Infrastructure.Core
{
    using Azox.Business.Core.Domain;
    using Azox.Business.Core.Service;
    using Azox.Core;
    using Azox.Core.Reflection;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// 
    /// </summary>
    internal class InstallationService :
        IInstallationService
    {
        #region Fields

        private readonly object _lock = new();

        private readonly ILogger _logger;
        private readonly ITypeFinder _typeFinder;
        private readonly IServiceProvider _serviceProvider;

        private bool _installed;

        #endregion Fields

        #region Ctor

        public InstallationService(
            ILogger<InstallationService> logger,
            ITypeFinder typeFinder,
            IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _typeFinder = typeFinder;
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
                    IInstallationStepService stepService = _serviceProvider
                        .GetRequiredService<IInstallationStepService>();

                    IEnumerable<IInstallationStep> installationSteps = _typeFinder
                        .FindInstancesOf<IInstallationStep>()
                        .OrderBy(x => x.Priority);

                    foreach (IInstallationStep step in installationSteps)
                    {
                        string stepName = step.GetType().FullName;
                        try
                        {
                            if (!step.IsRecurring)
                            {
                                InstallationStep stepEntity = null;

                                try
                                {
                                    stepEntity = stepService.GetStep(stepName)
                                        ?? new InstallationStep { StepName = stepName };
                                }
                                catch { }

                                if (stepEntity != null)
                                {
                                    if (stepEntity.Success)
                                    {
                                        continue;
                                    }

                                    try
                                    {
                                        step.Install(_serviceProvider);

                                        stepEntity.Success = true;
                                        stepEntity.LastExecutionTime = DateTime.Now;
                                    }
                                    catch (Exception ex)
                                    {
                                        stepEntity.Success = false;
                                        stepEntity.Error = ex.Message;
                                    }

                                    stepService.Update(stepEntity);
                                }
                            }
                            else
                            {
                                try
                                {
                                    step.Install(_serviceProvider);
                                }
                                catch (Exception)
                                {
                                    throw;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, ex.Message);
                            throw new AzoxBugException($"Installation Error. StepName : {stepName}");
                        }
                    }

                    _installed = true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
            }
        }

        #endregion Methods
    }
}
