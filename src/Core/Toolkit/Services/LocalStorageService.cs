namespace Azox.Toolkit.Blazor.Services
{
    using Azox.Core;
    using Azox.Core.Extensions;
    using Microsoft.JSInterop;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class LocalStorageService :
        ILocalStorageService
    {
        #region Fields

        private readonly IJSRuntime _jsRuntime;

        #endregion Fields

        #region Ctor

        public LocalStorageService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        #endregion Ctor

        #region Methods

        public async ValueTask ClearAsync(CancellationToken? cancellationToken = null) =>
            await _jsRuntime.InvokeVoidAsync("localStorage.clear", cancellationToken ?? CancellationToken.None);

        public async ValueTask<string> GetItemAsStringAsync(string key, CancellationToken? cancellationToken = null)
        {
            if (key.IsNullOrEmpty())
            {
                throw new AzoxBugException($"Argument null. {nameof(key)}:{key}");
            }

            return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", cancellationToken ?? CancellationToken.None, key);
        }

        public async ValueTask<T> GetItemAsync<T>(string key, CancellationToken? cancellationToken = null)
        {
            if (key.IsNullOrEmpty())
            {
                throw new AzoxBugException($"Argument null. {nameof(key)}:{key}");
            }

            string data = await GetItemAsStringAsync(key, cancellationToken);

            if (data.IsNullOrEmpty())
            {
                return default;
            }

            try
            {
                return JsonSerializer.Deserialize<T>(data);
            }
            catch (JsonException e) when (e.Path == "$" && typeof(T) == typeof(string))
            {
                return (T)(object)data;
            }
        }

        public async ValueTask RemoveItemAsync(string key, CancellationToken? cancellationToken = null)
        {
            if (key.IsNullOrEmpty())
            {
                throw new AzoxBugException($"Argument null. {nameof(key)}:{key}");
            }

            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", cancellationToken ?? CancellationToken.None, key);
        }

        public async ValueTask SetItemAsStringAsync(string key, string data, CancellationToken? cancellationToken = null)
        {
            if (key.IsNullOrEmpty())
            {
                throw new AzoxBugException($"Argument null. {nameof(key)}:{key}");
            }

            if (data.IsNullOrEmpty())
            {
                throw new AzoxBugException($"Argument null. {nameof(data)}:{data}");
            }

            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", cancellationToken ?? CancellationToken.None, key, data);
        }

        public async ValueTask SetItemAsync<T>(string key, T data, CancellationToken? cancellationToken = null)
        {
            if (key.IsNullOrEmpty())
            {
                throw new AzoxBugException($"Argument null. {nameof(key)}:{key}");
            }

            string serializedData = JsonSerializer.Serialize<T>(data);
            await SetItemAsStringAsync(key, serializedData, cancellationToken ?? CancellationToken.None);
        }

        #endregion Methods
    }
}
