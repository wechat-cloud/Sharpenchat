using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Xunit;

namespace Sharpenchat.Tests
{
    public class DefaultJsonSerializerTest
    {
        [Fact]
        public async void serialize_simple_object() {
            var target = new TestJsonObject {
                IntegerProp = 1,
                StringProp = "a"
            };

            var serializer = new DefaultJsonSerializer();
            using (var stream = new MemoryStream()) {
                using (var writer = new StreamWriter(stream, Encoding.UTF8)) {
                    await serializer.SerializeAsync(target, writer);
                    writer.Flush();
                    stream.Seek(0, SeekOrigin.Begin);

                    using (var reader = new StreamReader(stream)) {
                        var json = reader.ReadToEnd();
                        Assert.NotNull(json);
                        Assert.Equal("{\"integerProp\":1,\"stringProp\":\"a\"}", json);
                    }
                }
            }
        }
    }

    [DataContract]
    public class TestJsonObject
    {
        [DataMember(Name = "integerProp")]
        public int IntegerProp { get; set; }

        [DataMember(Name = "stringProp")]
        public string StringProp { get; set; }
    }
}