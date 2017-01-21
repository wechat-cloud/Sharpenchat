using System.Security.Cryptography;
using System.Text;
using Sharpenchat.Core;

namespace Sharpenchat
{
    public class DefaultDigestMd5 : IDigestMd5
    {
        public string Process(string raw) {
            var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(raw);

            var hash = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++) {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}