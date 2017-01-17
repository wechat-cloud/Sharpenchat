using Sharpenchat.Core.Serialization;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Sharpenchat.Plugins.JsonNet
{
    public class JsonNetSerializer : IJsonSerializer
    {
        public async Task<T> DeserializeAsync<T>(TextReader reader) {
            throw new NotImplementedException();
        }

        public async Task SerializeAsync<T>(T source, TextWriter writer) {
            throw new NotImplementedException();
        }
    }
}
