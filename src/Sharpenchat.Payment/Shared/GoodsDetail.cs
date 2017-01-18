using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Sharpenchat.Core.Serialization;

namespace Sharpenchat.Payment
{
    public class GoodsDetail
    {
        [FieldName("goods_id")]
        [Required]
        [MaxLength(32)]
        public string goods_id;

        [FieldName("goods_name")]
        [Required]
        [MaxLength(256)]
        public string goods_name;

        [FieldName("price")]
        public int price;

        [FieldName("quantity")]
        public int quantity;

        [FieldName("wxpay_goods_id")]
        [Required]
        [MaxLength(32)]
        public string wxpay_goods_id;
    }
}