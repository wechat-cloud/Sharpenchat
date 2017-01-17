using System;
using System.IO;
using System.Threading.Tasks;

namespace Sharpenchat.Core.Serialization
{
    public interface IJsonSerializer
    {
        Task SerializeAsync<T>(T source, TextWriter writer);
        Task<T> DeserializeAsync<T>(TextReader reader);
    }
}
