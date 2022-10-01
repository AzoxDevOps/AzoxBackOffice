namespace Azox.Core.Eventing
{
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public partial interface IEventHandlerService
    {
        /// <summary>
        /// 
        /// </summary>
        Task HandleAsync<TEventHandler, T>(T obj)
            where TEventHandler : IEventHandler<T>;
    }
}
