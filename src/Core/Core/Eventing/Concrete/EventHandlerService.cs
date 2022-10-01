namespace Azox.Core.Eventing
{
    using Azox.Core.Reflection;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// 
    /// </summary>
    internal partial class EventHandlerService :
        IEventHandlerService
    {
        #region Fields

        private readonly Dictionary<string, List<IEventHandler>> _eventHandlers;
        private readonly IServiceProvider _serviceProvider;

        #endregion Fields

        #region Ctor

        public EventHandlerService(IServiceProvider serviceProvider)
        {
            _eventHandlers = new();
            _serviceProvider = serviceProvider;
        }

        #endregion Ctor

        #region Utils

        private IEnumerable<IEventHandler<T>> GetEventHandlers<TEventHandler, T>()
        {
            string eventHandlerTypeName = typeof(TEventHandler).FullName;

            if (!_eventHandlers.TryGetValue(eventHandlerTypeName, out List<IEventHandler> eventHandlers))
            {
                try
                {
                    _eventHandlers[eventHandlerTypeName] = new();

                    IServiceProvider serviceProvider = _serviceProvider
                        .CreateScope().ServiceProvider;

                    ITypeFinder typeFinder = _serviceProvider.GetRequiredService<ITypeFinder>();

                    foreach (Type eventHandlerType in typeFinder.FindClassesOf<TEventHandler>())
                    {
                        IEventHandler eventHandler = (IEventHandler)Activator.CreateInstance(eventHandlerType, new object[] { serviceProvider });

                        _eventHandlers[eventHandlerTypeName].Add(eventHandler);
                    }

                    eventHandlers = _eventHandlers[eventHandlerTypeName];
                }
                catch (Exception ex)
                {
                    throw new AzoxBugException(ex.Message);
                }
            }

            foreach (IEventHandler eventHandler in eventHandlers)
            {
                yield return (IEventHandler<T>)eventHandler;
            }
        }

        #endregion Utils

        #region Methods

        public void Handle<TEventHandler, T>(T obj)
            where TEventHandler : IEventHandler<T>
        {
            foreach (IEventHandler<T> eventHandler in GetEventHandlers<TEventHandler, T>())
            {
                eventHandler.Handle(obj);
            }
        }

        #endregion Methods
    }
}
