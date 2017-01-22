using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sharpenchat.Core.Serialization;
using Xunit;

namespace Sharpenchat.Tests
{
    public class DefaultXmlSerializerTest
    {
        [Fact]
        public async void serialize_simple_object() {
            var serializer = new DefaultXmlSerializer();
            var obj = new TestXmlClass {
                IgnoreA = 11,
                B = 10,
                C = "hello",
                UnsafeD = @"<html></html>",
                RealA = "a"
            };

            using (var stream = new MemoryStream()) {
                using (var writer = new StreamWriter(stream, Encoding.UTF8)) {
                    await serializer.SerializeAsync(obj, writer);
                    writer.Flush();
                    stream.Seek(0, SeekOrigin.Begin);

                    using (var reader = new StreamReader(stream)) {
                        var xml = reader.ReadToEnd();
                        Assert.NotNull(xml);
                        var expected =
@"<xml>
<a><![CDATA[a]]></a>
<b>10</b>
<c><![CDATA[hello]]></c>
<d><![CDATA[<html></html>]]></d>
</xml>
";
                        Assert.Equal(expected, xml);
                    }
                }
            }
        }
    }

    public class TestXmlClass
    {
        [Ignore]
        public int IgnoreA { get; set; }
        [FieldName("b")]
        public int B { get; set; }
        [FieldName("c")]
        public string C { get; set; }
        [FieldName("d"), Protect]
        public string UnsafeD { get; set; }
        [FieldName("a")]
        public string RealA { get; set; }
    }
}
