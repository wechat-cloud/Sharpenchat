using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Sharpenchat.Core.Serialization;

namespace Sharpenchat
{
    internal class DefaultJsonSerializer : IJsonSerializer
    {
        public async Task SerializeAsync<T>(T source, TextWriter writer) {
            var serializer = new DataContractJsonSerializer(typeof(T));
            using (var stream = new MemoryStream()) {
                serializer.WriteObject(stream, source);

                stream.Seek(0, SeekOrigin.Begin);

                using (var reader = new StreamReader(stream)) {
                    var json = await reader.ReadToEndAsync();
                    await writer.WriteAsync(json);
                }
            }
        }

        public async Task<T> DeserializeAsync<T>(TextReader reader) {
            var serializer = new DataContractJsonSerializer(typeof(T));
            var json = await reader.ReadToEndAsync();

            using (var stream = new MemoryStream()) {
                using (var writer = new StreamWriter(stream)) {
                    await writer.WriteAsync(json);
                    await writer.FlushAsync();
                    stream.Seek(0, SeekOrigin.Begin);

                    return (T) serializer.ReadObject(stream);
                }
            }
        }
    }
}