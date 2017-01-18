namespace Sharpenchat.Payment
{
    public interface INativePayment : IPayment
    {
        void UnifiedOrder();
        void Shorturl();
        void AuthCodeToOpenId();
    }
}