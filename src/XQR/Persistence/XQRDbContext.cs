namespace Azox.XQR.Persistence
{
    using Azox.Persistence.Core;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// 
    /// </summary>
    internal class XQRDbContext :
        DbContext,
        IDbContext
    {
        #region Ctor

        public XQRDbContext(DbContextOptions<XQRDbContext> options) :
            base(options)
        {

        }

        #endregion Ctor
    }
}
