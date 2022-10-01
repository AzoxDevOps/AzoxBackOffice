namespace Azox.Core.Eventing
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEventHandler
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public partial interface IEventHandler<T> :
        IEventHandler
    {
        /// <summary>
        /// 
        /// </summary>
        void Handle(T obj);
    }
}
