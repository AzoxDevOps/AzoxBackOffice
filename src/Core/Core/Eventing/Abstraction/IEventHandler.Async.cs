namespace Azox.Core.Eventing
{
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public partial interface IEventHandler<T>
    {
        /// <summary>
        /// 
        /// </summary>
        Task HandleAsync(T obj);
    }
}
