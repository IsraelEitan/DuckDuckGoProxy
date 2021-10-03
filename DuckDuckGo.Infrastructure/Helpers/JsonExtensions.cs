
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace DuckDuckGo.Infrastructure.Helpers
{
    public static class JsonExtensions
    {
        private static readonly JsonSerializerOptions _jsonOptions =
             new JsonSerializerOptions
             {
                 PropertyNameCaseInsensitive = true,
                 IncludeFields = true
             }
         ;

        public static string ToJson<T>(this T obj)
        {
            return JsonSerializer.Serialize<T>(obj, _jsonOptions);
        }

        public static T FromJson<T>(this string json)
        {
            return JsonSerializer.Deserialize<T>(json, _jsonOptions);
        }

        public static async Task ToJsonAsync<T>(this T obj, Stream stream)
        {
            await JsonSerializer.SerializeAsync(stream, obj, typeof(T), _jsonOptions);
        }

        public static async Task<T> FromJsonAsync<T>(this Stream stream)
        {
            return await JsonSerializer.DeserializeAsync<T>(stream, _jsonOptions);
        }

    }
}
