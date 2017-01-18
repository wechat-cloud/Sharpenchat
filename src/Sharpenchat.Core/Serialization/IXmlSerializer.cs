using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Sharpenchat.Core.Serialization
{
    public interface IXmlSerializer
    {
        Task SerializeAsync<T>(T target, TextWriter writer);
        Task<T> DeserializeAsync<T>(TextReader reader);
    }
}
