﻿namespace Azox.Toolkit.Blazor.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILocalStorageService
    {
        /// <summary>
        /// 
        /// </summary>
        ValueTask ClearAsync(CancellationToken? cancellationToken = null);

        /// <summary>
        /// 
        /// </summary>
        ValueTask<T> GetItemAsync<T>(string key, CancellationToken? cancellationToken = null);

        /// <summary>
        /// 
        /// </summary>
        ValueTask<string> GetItemAsStringAsync(string key, CancellationToken? cancellationToken = null);

        /// <summary>
        /// 
        /// </summary>
        ValueTask RemoveItemAsync(string key, CancellationToken? cancellationToken = null);

        /// <summary>
        /// 
        /// </summary>
        ValueTask SetItemAsync<T>(string key, T data, CancellationToken? cancellationToken = null);

        /// <summary>
        /// 
        /// </summary>
        ValueTask SetItemAsStringAsync(string key, string data, CancellationToken? cancellationToken = null);
    }
}