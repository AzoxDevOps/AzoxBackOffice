namespace Azox.XQR.Presentation.Middlewares
{
    using Azox.XQR.Presentation.Services;
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    internal class InstallationMiddleware
    {
        #region Fields

        private readonly RequestDelegate _next;
        private readonly InstallationService _installationService;

        #endregion Fields

        #region Ctor

        public InstallationMiddleware(
            RequestDelegate next,
            InstallationService installationService)
        {
            _next = next;
            _installationService = installationService;
        }

        #endregion Ctor

        #region Methods

        public async Task Invoke(HttpContext httpContext)
        {
            if (!_installationService.Installed)
            {
                _installationService.Install();
            }

            await _next(httpContext);
        }

        #endregion Methods
    }

}
