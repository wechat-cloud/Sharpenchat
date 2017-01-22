using System;
using System.Collections.Generic;
using System.Text;
using Sharpenchat.Core.Container;

namespace Sharpenchat
{
    public class WechatConfiguration
    {
        public IServiceRegistry Registry { get; }
        public IServiceResolver Resolver { get; set; }
        public void Configure() { }
        public void ExportAllServices(Action action) { }

        public void SetupResolver() { }
    }
}
