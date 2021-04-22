using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
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
        public static async Task<T> GetFromSession<T>(this ProtectedLocalStorage session, string key)
        {
            ProtectedBrowserStorageResult<string> value = await session.GetAsync<string>(key);
            return value.Value == null ? default : JsonSerializer.Deserialize<T>(value.Value);
        }
    }
}
