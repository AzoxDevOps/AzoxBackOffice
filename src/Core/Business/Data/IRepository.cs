namespace Azox.Business.Core.Data
{
    using Azox.Business.Core.Domain;

    /// <summary>
    /// 
    /// </summary>
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        TEntity GetById(Guid id);

        /// <summary>
        /// 
        /// </summary>
        TEntity GetById(int id);
    }
}
