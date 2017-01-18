namespace Sharpenchat.Payment
{
    public interface IAppPayment : IPayment
    {
        void UnifiedOrder();
    }
}