using Sharpenchat.Core.Serialization;
using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sharpenchat.Plugins.JsonNet
{
    public class JsonNetSerializer : IJsonSerializer
    {
        private readonly JsonSerializer _serializer;
        public JsonNetSerializer()
        {
            _serializer = new JsonSerializer();
        }

        public async Task<T> DeserializeAsync<T>(TextReader reader) {
            var jsonTextReader = new JsonTextReader(reader);
            var result = _serializer.Deserialize<T>(jsonTextReader);
            return await Task.FromResult(result);
        }

        public async Task SerializeAsync<T>(T source, TextWriter writer) {
            var jsonTextWriter = new JsonTextWriter(writer);
            await Task.Run(() => {
                _serializer.Serialize(jsonTextWriter, source);
            });
        }
    }
}
