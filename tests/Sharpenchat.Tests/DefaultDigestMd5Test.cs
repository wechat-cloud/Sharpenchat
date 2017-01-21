using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sharpenchat.Tests
{
    public class DefaultDigestMd5Test
    {
        [Fact]
        public void digest_by_string() {
            var md5 = new DefaultDigestMd5();
            var raw = @"appid=abcdefg&body=ccccc&device_info=aaaaa&mch_id=123456&nonce_str=bbbbb&key=987654321";
            var hash = md5.Process(raw);
            Assert.Equal("9403F5786B482A61E3F9FDDD74A7C2E2", hash);
        }
    }
}
