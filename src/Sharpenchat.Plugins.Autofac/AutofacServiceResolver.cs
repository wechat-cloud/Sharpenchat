using Autofac;
using Sharpenchat.Core.Container;

namespace Sharpenchat.Plugins.Autofac
{
    internal class AutofacServiceResolver : IServiceResolver
    {
        private readonly IContainer _innerContainer;

        public AutofacServiceResolver(IContainer innerContainer) {
            _innerContainer = innerContainer;
        }

        public IServiceRegistry RequestRegistry() {
            var scope = _innerContainer.BeginLifetimeScope();
            var registry = new AutofacServiceRegistry(scope);
            return registry;
        }
    }
}