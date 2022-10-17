namespace Azox.Core.Eventing
{
    using System.Reactive.Subjects;

    /// <summary>
    /// 
    /// </summary>
    internal class EventSource<TEvent>
        where TEvent : IEvent
    {
        #region Fields

        private readonly Subject<TEvent> _source;

        #endregion Fields

        #region Ctor

        public EventSource()
        {
            _source = new();
        }

        #endregion Ctor

        #region Methods

        public void Consume(Action<TEvent> acquire)
        {
            _source.Subscribe(acquire);
        }

        public void Publish(TEvent @event)
        {
            _source.OnNext(@event);
        }

        #endregion Methods
    }
}
