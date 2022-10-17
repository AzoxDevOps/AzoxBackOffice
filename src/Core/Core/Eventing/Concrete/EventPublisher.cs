namespace Azox.Core.Eventing
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// 
    /// </summary>
    internal class EventPublisher :
        IEventPublisher
    {
        #region Fields

        private readonly IServiceProvider _serviceProvider;

        #endregion Fields

        #region Ctor

        public EventPublisher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        #endregion Ctor

        #region Methods

        public void Publish<TEvent>(TEvent @event)
            where TEvent : class, IEvent
        {
            EventSource<TEvent> eventSource = _serviceProvider
                .GetRequiredService<EventSource<TEvent>>();

            eventSource.Publish(@event);
        }

        #endregion Methods
    }
}
