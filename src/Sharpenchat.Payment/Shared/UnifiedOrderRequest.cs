using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sharpenchat.Core.Serialization;

namespace Sharpenchat.Payment
{
    public class UnifiedOrderRequest
    {
        [FieldName("appid"), Required, MaxLength(32)]
        internal string AppId { get; set; }

        [FieldName("mch_id"), Required, MaxLength(32)]
        internal string MchId { get; set; }

        [FieldName("nonce_str"), Required, MaxLength(32)]
        internal string NonceStr { get; set; }

        [FieldName("sign"), Required, MaxLength(32)]
        internal string Sign { get; set; }

        [FieldName("sign_type")]
        internal string SignType { get; set; }

        [Ignore]
        internal SignType EmbedSignType { get; set; }


        [FieldName("attach"), MaxLength(127)]
        public string Attach { get; set; }

        [FieldName("body"), Required, MaxLength(128)]
        public string Body { get; set; }

        [FieldName("device_info")]
        public string DeviceInfo { get; set; }

        [FieldName("fee_type"), MaxLength(16)]
        public string FeeType { get; set; }

        [Ignore]
        public FeeType EmbedFeeType { get; set; }

        [FieldName("goods_tag"), MaxLength(32)]
        public string GoodsTag { get; set; }

        [FieldName("limit_pay"), MaxLength(32)]
        internal string LimitPay { get; set; }

        [Ignore]
        public LimitPay EmbedLimitPay { get; set; }

        [FieldName("notify_url"), Required, MaxLength(256)]
        public string NotifyUrl { get; set; }

        [FieldName("out_trade_no"), Required, MaxLength(32)]
        public string OutTradeNo { get; set; }

        [FieldName("spbill_create_ip"), Required, MaxLength(16)]
        public string SpbillCreateIp { get; set; }

        [FieldName("time_expire"), Required, MaxLength(14)]
        public string TimeExpire { get; set; }

        [FieldName("time_start"), Required, MaxLength(14)]
        public string TimeStart { get; set; }

        [FieldName("total_fee")]
        public int TotalFee { get; set; }

        [FieldName("trade_type"), Required, MaxLength(16)]
        internal string TradeType { get; set; }

        [Ignore]
        public TradeType EmbedTradeType { get; set; }

        [FieldName("detail")]
        internal string Detail { get; set; }

        [Ignore]
        public UnifiedOrderDetail EmbedDetail { get; set; }

        [FieldName("product_id"), MaxLength(32)]
        public string ProductId { get; set; }

        [FieldName("openid"), MaxLength(128)]
        public string OpenId { get; set; }

        internal void Preparing(PaymentContext paymentContext) {
            if (EmbedTradeType == null) {
                throw new ValidationException("trade_type is required");
            }

            if (EmbedDetail != null) {
                Detail = paymentContext.JsonSerializer.SerializeSync(EmbedDetail);
            }

            SignType = EmbedSignType?.ToString();
            FeeType = EmbedFeeType?.ToString();
            LimitPay = EmbedLimitPay?.ToString();
            TradeType = EmbedTradeType?.ToString();

            AppId = paymentContext.AppId;
            MchId = paymentContext.MchId;
        }
    }

    public class UnifiedOrderDetail
    {
        public UnifiedOrderDetail() {
            GoodsDetail = new List<GoodsDetail>();
        }

        [Required, FieldName("goods_detail")]
        public IList<GoodsDetail> GoodsDetail { get; set; }

        #region jsapi & native

        public int? cost_price { get; set; }

        [MaxLength(32)]
        public string receipt_id { get; set; }

        #endregion
    }

    public class GoodsDetail
    {
        [FieldName("goods_id"), Required, MaxLength(32)]
        public string GoodsId { get; set; }

        [FieldName("goods_name"), Required, MaxLength(256)]
        public string GoodsName { get; set; }

        [FieldName("price")]
        public int Price { get; set; }

        [FieldName("quantity")]
        public int Quantity { get; set; }

        [FieldName("wxpay_goods_id"), Required, MaxLength(32)]
        public string WxpayGoodsId { get; set; }

        #region app

        [FieldName("goods_category"), MaxLength(32)]
        public string GoodsCategory { get; set; }

        [FieldName("body"), MaxLength(1000)]
        public string Body { get; set; }

        #endregion
    }

    public class SignType
    {
        private readonly string _typeValue;

        private SignType(string typeValue) {
            _typeValue = typeValue;
        }

        public static SignType Md5 => new SignType("MD5");
        public static SignType HmacSha256 => new SignType("HMAC-SHA256");

        public override string ToString() {
            return _typeValue;
        }
    }

    public class TradeType
    {
        private readonly string _typeValue;

        private TradeType(string typeValue) {
            _typeValue = typeValue;
        }

        public static TradeType App => new TradeType("APP");
        public static TradeType Jsapi => new TradeType("JSAPI");
        public static TradeType Native => new TradeType("NATIVE");

        public override string ToString() {
            return _typeValue;
        }
    }

    public class FeeType
    {
        private readonly string _typeValue;

        private FeeType(string typeValue) {
            _typeValue = typeValue;
        }

        public static FeeType Cny => new FeeType("CNY");

        public override string ToString() {
            return _typeValue;
        }
    }

    public class LimitPay
    {
        private readonly string _typeValue;

        private LimitPay(string typeValue) {
            _typeValue = typeValue;
        }

        public static LimitPay NoCredit => new LimitPay("no_credit");

        public override string ToString() {
            return _typeValue;
        }
    }
}