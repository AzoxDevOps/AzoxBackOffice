namespace Azox.Business.Core.Service
{
    using Azox.Business.Core.Domain;
    using System.Linq.Expressions;

    /// <summary>
    /// 
    /// </summary>
    public interface IEntityService
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IEntityService<TEntity> :
        IEntityService
        where TEntity : class, IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
    }
}
