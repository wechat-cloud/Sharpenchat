namespace Sharpenchat.Core.Container
{
    public interface IServiceContainerBuilder
    {
        IServiceContainerBuilder Register<TInterface, TImplementation>() where TImplementation : TInterface, new();
        IServiceContainerBuilder Replace<TInterface, TImplementation>() where TImplementation : TInterface, new();
        IServiceResolver BuildContainer();
    }
}