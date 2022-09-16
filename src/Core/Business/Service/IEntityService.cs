namespace Azox.Business.Core.Service
{
    using Azox.Business.Core.Domain;

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

    }
}
