namespace Azox.Infrastructure.Core
{
    using Azox.Business.Core.Domain;
    using Azox.Core.Eventing;

    /// <summary>
    /// 
    /// </summary>
    public interface IEntityDeletedEventHandler<TEntity> :
        IEventHandler<TEntity>
        where TEntity : class, IEntity
    {
    }
}
