namespace Azox.Toolkit.Blazor.Helpers
{
    using Microsoft.JSInterop;

    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    internal class JsRuntimeHelper :
        IJsRuntimeHelper
    {
        #region Fields

        private readonly IJSRuntime _jsRuntime;

        #endregion Fields

        #region Ctor

        public JsRuntimeHelper(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }


        #endregion Ctor

        #region Methods

        public async Task<bool> GetConfirmResult(string message)
        {
            bool result = await _jsRuntime.InvokeAsync<bool>("confirm", message);
            return result;
        }

        #endregion Methods
    }
}
