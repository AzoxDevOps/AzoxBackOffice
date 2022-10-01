namespace Azox.Core.Eventing
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class EventHandlerService
    {
        #region Methods

        public async Task HandleAsync<TEventHandler, T>(T obj)
            where TEventHandler : IEventHandler<T>
        {
            foreach (IEventHandler<T> eventHandler in GetEventHandlers<TEventHandler,T>())
            {
                await eventHandler.HandleAsync(obj);
            }
        }

        #endregion Methods
    }
}
