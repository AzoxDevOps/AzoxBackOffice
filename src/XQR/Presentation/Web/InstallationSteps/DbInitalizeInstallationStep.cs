namespace Azox.XQR.Presentation.Web.InstallationSteps
{
    using Azox.Infrastructure.Core;
    using Azox.Persistence.Core;

    using Microsoft.EntityFrameworkCore;

    internal class DbInitalizeInstallationStep :
        IInstallationStep
    {
        #region Methods

        public void Install(IServiceProvider serviceProvider)
        {
            IDbContext dbContext = serviceProvider.GetRequiredService<IDbContext>();

            dbContext.Database.Migrate();
        }

        #endregion Methods

        #region Properties

        public int Priority => int.MinValue;

        public bool IsRecurring => true;

        #endregion Properties
    }
}
