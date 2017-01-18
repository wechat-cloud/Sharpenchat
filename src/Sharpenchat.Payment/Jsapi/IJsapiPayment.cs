namespace Sharpenchat.Payment
{
    public interface IJsapiPayment : IPayment
    {
        void UnifiedOrder();
    }
}