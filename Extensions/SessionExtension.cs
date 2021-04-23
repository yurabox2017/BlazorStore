using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorStore.Extensions
{
    public static class SessionExtension
    {
        public static async Task SetInSession<T>(this ProtectedLocalStorage session, string key, T value)
        {
            await session.SetAsync(key, JsonSerializer.Serialize(value));
        }
        public static async Task<string> GetFromSession<T>(this ProtectedLocalStorage session, string key)
        {
            var value = await session.GetAsync<string>(key);
            return value.Value == null ? default : value.Value;
        }
    }
}
