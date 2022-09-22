namespace Azox.Persistence.Core
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;

    /// <summary>
    /// 
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        DatabaseFacade Database { get; }
    }
}
