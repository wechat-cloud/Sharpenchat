using System.Security.Cryptography;
using System.Text;
using Sharpenchat.Core;

namespace Sharpenchat
{
    public class DefaultDigestHmacSha256 : IDigestHmacSha256
    {
        public string Process(string raw) {
            var sha256 = SHA256.Create();
            var inputBytes = Encoding.ASCII.GetBytes(raw);

            var hash = sha256.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++) {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}