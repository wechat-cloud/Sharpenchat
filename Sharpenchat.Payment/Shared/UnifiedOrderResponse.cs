namespace Sharpenchat.Payment
{
    public class UnifiedOrderResponse
    {
        public string return_code;
        public string return_msg;
        public string appid;
        public string mch_id;
        public string device_info;
        public string nonce_str;
        public string sign;
        public string result_code;
        public string err_code;
        public string err_code_des;
        public string trade_type;
        public string prepay_id;
        public string code_url;
    }
}