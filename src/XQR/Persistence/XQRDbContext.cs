namespace Azox.XQR.Persistence
{
    using Azox.Core.Reflection;
    using Azox.Persistence.Core;
    using Azox.Persistence.Core.Mapping;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// 
    /// </summary>
    internal class XQRDbContext :
        DbContextBase<XQRDbContext>
    {
        #region Ctor

        public XQRDbContext(
            IServiceProvider serviceProvider,
            DbContextOptions<XQRDbContext> options) :
            base(serviceProvider,options)
        {
        }

        #endregion Ctor
    }
}
