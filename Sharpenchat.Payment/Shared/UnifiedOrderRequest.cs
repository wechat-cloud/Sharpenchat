using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Sharpenchat.Core.Serialization;

namespace Sharpenchat.Payment
{
    public class UnifiedOrderRequest
    {
        [FieldName("appid")]
        [Required]
        [MaxLength(32)]
        internal string appid;

        [FieldName("attach")]
        [MaxLength(127)]
        internal string attach;

        [FieldName("body")]
        [Required]
        [MaxLength(128)]
        internal string body;

        [FieldName("device_info")]
        internal string device_info;

        [FieldName("fee_type")]
        [MaxLength(16)]
        internal string fee_type;

        [FieldName("goods_tag")]
        [MaxLength(32)]
        internal string goods_tag;

        [FieldName("limit_pay")]
        [MaxLength(32)]
        internal string limit_pay;

        [FieldName("mch_id")]
        [Required]
        [MaxLength(32)]
        internal string mch_id;

        [FieldName("nonce_str")]
        [Required]
        [MaxLength(32)]
        internal string nonce_str;

        [FieldName("notify_url")]
        [Required]
        [MaxLength(256)]
        internal string notify_url;

        [FieldName("out_trade_no")]
        [Required]
        [MaxLength(32)]
        internal string out_trade_no;

        [FieldName("sign")]
        [Required]
        [MaxLength(32)]
        internal string sign;

        [FieldName("sign_type")]
        internal string sign_type;

        [FieldName("spbill_create_ip")]
        [Required]
        [MaxLength(16)]
        internal string spbill_create_ip;

        [FieldName("time_expire")]
        [Required]
        [MaxLength(14)]
        internal string time_expire;

        [FieldName("time_start")]
        [Required]
        [MaxLength(14)]
        internal string time_start;

        [FieldName("total_fee")]
        public int total_fee;

        [FieldName("trade_type")]
        [Required]
        [MaxLength(16)]
        internal string trade_type;
    }
}