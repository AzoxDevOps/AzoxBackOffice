namespace Azox.Persistence.Core
{
    using Azox.Business.Core.Domain;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// 
    /// </summary>
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;
    }
}
