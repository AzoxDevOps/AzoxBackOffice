namespace Azox.XQR.Presentation.Web.Middlewares
{
    using Azox.Infrastructure.Core;

    public class InstallationMiddleware
    {
        #region Fields

        private readonly IInstallationService _installationService;
        private readonly RequestDelegate _next;

        #endregion Fields

        #region Ctor

        public InstallationMiddleware(
            IInstallationService installationService,
            RequestDelegate next)
        {
            _installationService = installationService;
            _next = next;
        }

        #endregion Ctor

        #region Methods

        public async Task InvokeAsync(HttpContext context)
        {
            _installationService.Install();
            await _next(context);
        }

        #endregion Methods
    }
}
