using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

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
        public static async Task<T> DelFromSessionAsync<T>(this ProtectedLocalStorage session, string key, int itemId)
        {
            var value = await session.GetAsync<string>(key);
            var data = JsonConvert.DeserializeObject<T>(value.Value);
            await session.DeleteAsync(key);
            if (data is IList<int> d)
            {
                d.Remove(itemId);
                await session.SetAsync(key, JsonConvert.SerializeObject(data, Formatting.Indented));
            }
            else
                data = default(T);

            return data == null ? default(T) : data;
        }
    }
}
