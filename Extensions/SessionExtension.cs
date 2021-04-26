using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlazorStore.Extensions
{
    public static class SessionExtension
    {
        public static async Task SetInSession<T>(this ProtectedLocalStorage session, string key, T value)
        {
            await session.SetAsync(key, JsonConvert.SerializeObject(value, Formatting.Indented));
        }
        public static async Task<T> GetFromSession<T>(this ProtectedLocalStorage session, string key)
        {
            var value = await session.GetAsync<string>(key);
            return value.Value == null ? default(T) : JsonConvert.DeserializeObject<T>(value.Value);
        }
    }
}
