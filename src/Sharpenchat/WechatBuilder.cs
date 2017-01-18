using System;
using System.Collections.Generic;
using System.Text;
using Sharpenchat.Core.Container;

namespace Sharpenchat
{
    public class WechatBuilder
    {
        private readonly IServiceContainerBuilder _containerBuilder;

        public WechatBuilder() {
            _containerBuilder = new DefaultContainerBuilder();
        }

        public WechatBuilder(IServiceContainerBuilder containerBuilder) {
            _containerBuilder = containerBuilder;
        }

        public WechatBuilder Configure(Action<object> action) {
            throw new NotImplementedException();
        }
    }
}
