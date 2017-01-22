namespace Sharpenchat.Core.Container
{
    public interface IServiceResolver
    {
        IServiceRegistry RequestRegistry();
    }
}