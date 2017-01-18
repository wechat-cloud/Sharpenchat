using System;
using Sharpenchat.Core.Container;

namespace Sharpenchat
{
    public class DefaultContainerBuilder : IServiceContainerBuilder {
        public IServiceContainerBuilder Register<TInterface, TImplementation>() where TImplementation : TInterface, new() {
            throw new NotImplementedException();
        }

        public IServiceContainerBuilder Replace<TInterface, TImplementation>() where TImplementation : TInterface, new() {
            throw new NotImplementedException();
        }

        public IServiceContainer BuildContainer() {
            throw new NotImplementedException();
        }
    }
}