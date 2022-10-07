namespace Azox.XQR.Presentation.Web.Core.Middlewares
{
    using Azox.XQR.Presentation.Web.Core.Services;

    public class InstallationMiddleware
    {
        #region Fields

        private readonly IInstallationService _installerService;
        private readonly RequestDelegate _next;

        #endregion Fields

        #region Ctor

        public InstallationMiddleware(
            IInstallationService installationService,
            RequestDelegate next)
        {
            _installerService = installationService;
            _next = next;
        }

        #endregion Ctor

        #region Methods

        public async Task InvokeAsync(HttpContext context)
        {
            _installerService.Install();

            await _next(context);
        }

        #endregion Methods
    }
}
