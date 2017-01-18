using System.ComponentModel.DataAnnotations;

namespace Sharpenchat.Payment
{
    public class NativeUnifiedOrderRequest : UnifiedOrderRequest
    {
        [MaxLength(6000)]
        public string detail { get; set; }

        [MaxLength(32)]
        public string product_id { get; set; }

        [MaxLength(128)]
        public string openid { get; set; }
    }
}