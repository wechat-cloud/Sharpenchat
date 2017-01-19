using System;
using System.Threading.Tasks;

namespace Sharpenchat.Payment
{
    // JSAPI--公众号支付
    // NATIVE--原生扫码支付
    // APP--app支付
    // MICROPAY--刷卡支付
    public interface IPayment
    {
        Task<UnifiedOrderResponse> UnifiedOrder(UnifiedOrderRequest order);
        void OrderQuery();
        void CloseOrder();
        void Refund();
        void RefundQuery();
        void DownloadBill();
        void Report();
    }
}
