using System.IO;
using System.Text;

namespace Sharpenchat.Core.Serialization
{
    public static class JsonSerializerExtension
    {
        public static string SerializeSync<T>(this IJsonSerializer serializer, T source) {
            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb)) {
                serializer
                    .SerializeAsync(source, writer)
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();
                writer.Flush();
            }

            return sb.ToString();
        }
        
        public static T DeserializeSync<T>(this IJsonSerializer serializer, string source) {
            using (var reader = new StringReader(source)) {
                return serializer
                    .DeserializeAsync<T>(reader)
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();
            }
        }
    }
}