namespace Sharpenchat.Payment.Config
{
    internal class PaymentConfig
    {
        public PaymentApi Api { get; set; }
        public PaymentError[] Errors { get; set; }
    }

    internal class PaymentApi
    {
        public string UnifiedOrder { get; set; }
        public string OrderQuery { get; set; }
        public string CloseOrder { get; set; }
        public string Refund { get; set; }
        public string RefundQuery { get; set; }
        public string DownloadBill { get; set; }
        public string Report { get; set; }
        public string ShortUrl { get; set; }
        public string MicroPay { get; set; }
        public string Reverse { get; set; }
        public string AuthCodeToOpenId { get; set; }
    }

    internal class PaymentError
    {
        public string Code { get; set; }
        public string Desc { get; set; }
        public string Reason { get; set; }
        public string Solution { get; set; }
    }
}