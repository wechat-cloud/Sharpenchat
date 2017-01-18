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

    public class FieldName : Attribute
    {
        private readonly string _name;

        public FieldName(string name) {
            _name = name;
        }
    }
}
