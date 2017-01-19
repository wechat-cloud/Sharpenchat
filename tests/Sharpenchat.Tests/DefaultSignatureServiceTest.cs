using Sharpenchat.Core.Serialization;
using Xunit;

namespace Sharpenchat.Tests
{
    public class DefaultSignatureServiceTest
    {
        [Fact]
        public void gen_nonce() {
            var service = new DefaultSignatureService();
            var returns = service.GenNonce(nonce => {
                Assert.NotNull(nonce);
                Assert.False(string.IsNullOrEmpty(nonce));
                Assert.True(nonce.Length == 32);
            });

            Assert.Equal(service, returns);
        }


        [Fact]
        public void gen_nonce_with_null_callback() {
            var service = new DefaultSignatureService();
            var returns = service.GenNonce(null);

            Assert.Equal(service, returns);
        }

        [Fact]
        public void gen_sign() {
            var service = new DefaultSignatureService();
            var obj = new TestSignClass {
                B = "b",
                C = "c",
                D = "d"
            };

            service.GenSign("qazwsxedc", obj, sign => {
                
            });
        }
    }

    public class TestSignClass
    {
        public string B { get; set; }
        [FieldName("a")]
        public string C { get; set; }
        [Ignore]
        public string D { get; set; }
    }
}