using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Sharpenchat.Core.Serialization
{
    public static class JsonSerializerExtension
    {
        public static string Serialize<T>(this IJsonSerializer serializer, T source) {
            using (var stream = new MemoryStream()) {
                using (var writer = new StreamWriter(stream, Encoding.UTF8)) {
                    serializer
                        .SerializeAsync(source, writer)
                        .ConfigureAwait(false)
                        .GetAwaiter()
                        .GetResult();

                    writer.Flush();
                    stream.Seek(0, SeekOrigin.Begin);

                    using (var reader = new StreamReader(stream)) {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
    }
}
