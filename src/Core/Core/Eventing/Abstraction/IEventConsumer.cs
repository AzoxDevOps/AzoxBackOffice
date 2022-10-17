namespace Azox.Core.Eventing
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEventConsumer
    {
        /// <summary>
        /// 
        /// </summary>
        void Consume<TEvent>(Action<TEvent> acquire)
            where TEvent : class, IEvent;
    }
}
