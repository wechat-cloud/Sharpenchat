using System.ComponentModel.DataAnnotations;

namespace Sharpenchat.Payment
{
    public class JsapiGoodsDetail : GoodsDetail
    {
        public int? cost_price { get; set; }
        [MaxLength(32)]
        public string receipt_id { get; set; }
    }
}