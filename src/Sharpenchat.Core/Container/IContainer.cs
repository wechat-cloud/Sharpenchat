using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpenchat.Core.Container
{
    public interface IContainer
    {
        IContainer Register<TInterface, TImplementation>() where TImplementation : TInterface, new();
        IContainer Replace<TInterface, TImplementation>() where TImplementation : TInterface, new();
        IRegistry BuildRegistry();
    }
}
