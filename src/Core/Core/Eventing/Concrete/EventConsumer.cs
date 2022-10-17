namespace Azox.Core.Eventing
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// 
    /// </summary>
    internal class EventConsumer :
        IEventConsumer
    {
        #region Fields

        private readonly IServiceProvider _serviceProvider;

        #endregion Fields

        #region Ctor

        public EventConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        #endregion Ctor

        #region Methods

        public void Consume<TEvent>(Action<TEvent> acquire)
            where TEvent : class, IEvent
        {
            EventSource<TEvent> eventSource = _serviceProvider
                .GetRequiredService<EventSource<TEvent>>();

            eventSource.Consume(acquire);
        }

        #endregion Methods
    }
}
