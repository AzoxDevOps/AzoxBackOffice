namespace Azox.Infrastructure.Core.Eventing
{
    using Azox.Business.Core.Domain;
    using Azox.Core.Eventing;

    /// <summary>
    /// 
    /// </summary>
    public class EntityInsertedEvent<TEntity> :
        IEvent
        where TEntity : class, IEntity
    {
        #region Ctor

        public EntityInsertedEvent(TEntity entity)
        {
            Entity = entity;
        }

        #endregion Ctor

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public TEntity Entity { get; }

        #endregion Properties
    }
}
