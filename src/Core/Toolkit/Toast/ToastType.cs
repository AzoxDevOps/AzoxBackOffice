namespace Azox.Toolkit.Blazor
{
    /// <summary>
    /// 
    /// </summary>
    public class ToastType
    {
        /// <summary>
        /// 
        /// </summary>
        public static ToastType Error => new() { Style = "text-bg-danger" };

        /// <summary>
        /// 
        /// </summary>
        public static ToastType Info => new() { Style = "text-bg-info" };

        /// <summary>
        /// 
        /// </summary>
        public static ToastType Success => new() { Style = "text-bg-success" };

        /// <summary>
        /// 
        /// </summary>
        public static ToastType Warning => new() { Style = "text-bg-warning" };

        /// <summary>
        /// 
        /// </summary>
        internal string Style { get; set; }
    }
}