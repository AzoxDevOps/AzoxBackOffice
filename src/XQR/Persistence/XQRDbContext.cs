namespace Azox.XQR.Persistence
{
    using Azox.Persistence.Core;

    using Microsoft.EntityFrameworkCore;

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
            base(serviceProvider, options)
        {
            
        }

        #endregion Ctor
    }
}
