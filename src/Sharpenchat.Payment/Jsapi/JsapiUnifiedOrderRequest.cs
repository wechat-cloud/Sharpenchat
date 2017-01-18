using System.ComponentModel.DataAnnotations;

namespace Sharpenchat.Payment
{
    public class JsapiUnifiedOrderRequest : UnifiedOrderRequest
    {
        [MaxLength(6000)]
        public string detail { get; set; }

        public JsapiUnifiedOrderDetail Detail { internal get; set; }

        [MaxLength(32)]
        public string product_id { get; set; }

        [Required]
        [MaxLength(128)]
        public string openid { get; set; }
    }
}