using Autofac;
using Sharpenchat.Core.Container;

namespace Sharpenchat.Plugins.Autofac
{
    public class AutofacServiceContainerBuilder : IServiceContainerBuilder
    {
        private readonly ContainerBuilder _builder;

        public AutofacServiceContainerBuilder(ContainerBuilder builder) {
            _builder = builder;
        }

        public IServiceContainerBuilder Register<TInterface, TImplementation>() where TImplementation : TInterface, new() {
            _builder.RegisterType<TImplementation>().As<TInterface>();
            return this;
        }

        public IServiceContainerBuilder Replace<TInterface, TImplementation>() where TImplementation : TInterface, new() {
            return Register<TInterface, TImplementation>();
        }

        public IServiceContainer BuildContainer() {
            var inner = _builder.Build();
            return new AutofacServiceContainer(inner);
        }
    }
}