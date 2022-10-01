namespace Azox.Toolkit.Blazor
{
    /// <summary>
    /// 
    /// </summary>
    public class ToastMessage
    {
        /// <summary>
        /// 
        /// </summary>
        public int? Duration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ToastType Type { get; set; } = ToastType.Info;
    }
}