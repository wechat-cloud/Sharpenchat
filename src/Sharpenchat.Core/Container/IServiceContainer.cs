namespace Sharpenchat.Core.Container
{
    public interface IServiceContainer
    {
        IServiceRegistry RequestRegistry();
    }
}