namespace Azox.Core.Eventing
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEventPublisher
    {
        /// <summary>
        /// 
        /// </summary>
        void Publish<TEvent>(TEvent @event)
            where TEvent : class, IEvent;
    }
}
