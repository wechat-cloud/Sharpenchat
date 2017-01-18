using Autofac;
using Sharpenchat.Core.Container;

namespace Sharpenchat.Plugins.Autofac
{
    internal class AutofacServiceRegistry : IServiceRegistry
    {
        private readonly ILifetimeScope _scope;

        public AutofacServiceRegistry(ILifetimeScope scope) {
            _scope = scope;
        }

        public TInterface Resolve<TInterface>() {
            return _scope.Resolve<TInterface>();
        }
    }
}