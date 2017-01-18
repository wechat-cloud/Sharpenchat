using Autofac;
using Sharpenchat.Core.Container;

namespace Sharpenchat.Plugins.Autofac
{
    internal class AutofacServiceContainer : IServiceContainer
    {
        private readonly IContainer _innerContainer;

        public AutofacServiceContainer(IContainer innerContainer) {
            _innerContainer = innerContainer;
        }

        public IServiceRegistry RequestRegistry() {
            var scope = _innerContainer.BeginLifetimeScope();
            var registry = new AutofacServiceRegistry(scope);
            return registry;
        }
    }
}