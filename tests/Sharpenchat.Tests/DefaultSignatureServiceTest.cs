using NSubstitute;
using Sharpenchat.Core;
using Sharpenchat.Core.Serialization;
using Xunit;

namespace Sharpenchat.Tests
{
    public class DefaultSignatureServiceTest
    {
        [Fact]
        public void gen_nonce() {
            var service = new DefaultSignatureService(null, null);
            var returns = service.GenNonce(nonce => {
                Assert.NotNull(nonce);
                Assert.False(string.IsNullOrEmpty(nonce));
                Assert.True(nonce.Length == 32);
            });

            Assert.Equal(service, returns);
        }


        [Fact]
        public void gen_nonce_with_null_callback() {
            var service = new DefaultSignatureService(null, null);
            var returns = service.GenNonce(null);

            Assert.Equal(service, returns);
        }

        [Fact]
        public void gen_sign() {
            var md5 = Substitute.For<IDigestMd5>();
            var sha256 = Substitute.For<IDigestHmacSha256>();

            md5.Process(Arg.Any<string>()).Returns("aaaaa");
            sha256.Process(Arg.Any<string>()).Returns("bbbbb");

            var service = new DefaultSignatureService(md5, sha256);
            var obj = new TestSignClass {
                B = "b",
                C = "c",
                D = "d"
            };

            service.GenSign("a1b2c3", obj, sign => {
                Assert.Equal("aaaaa", sign);
            });

            md5.Received().Process("a=c&B=b&key=a1b2c3");
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