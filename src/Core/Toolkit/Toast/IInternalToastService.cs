namespace Azox.Toolkit.Blazor
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// 
    /// </summary>
    internal interface IInternalToastService
    {
        /// <summary>
        /// 
        /// </summary>
        ObservableCollection<ToastMessage> Messages { get; }
    }
}