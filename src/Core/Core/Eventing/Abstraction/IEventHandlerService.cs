namespace Azox.Core.Eventing
{
    /// <summary>
    /// 
    /// </summary>
    public partial interface IEventHandlerService
    {
        /// <summary>
        /// 
        /// </summary>
        void Handle<TEventHandler, T>(T obj)
            where TEventHandler : IEventHandler<T>;
    }
}
