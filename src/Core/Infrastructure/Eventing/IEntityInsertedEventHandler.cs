namespace Azox.Infrastructure.Core
{
    using Azox.Business.Core.Domain;
    using Azox.Core.Eventing;

    /// <summary>
    /// 
    /// </summary>
    public interface IEntityInsertedEventHandler<TEntity> :
        IEventHandler<TEntity>
        where TEntity : class, IEntity
    {
    }
}
