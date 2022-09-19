namespace Azox.Persistence.Core
{
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
