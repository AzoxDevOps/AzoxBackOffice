namespace Azox.Toolkit.Blazor.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IJsRuntimeHelper
    {
        /// <summary>
        /// 
        /// </summary>
        Task<bool> GetConfirmResult(string message);
    }
}