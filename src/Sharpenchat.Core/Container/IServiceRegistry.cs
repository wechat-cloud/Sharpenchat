﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpenchat.Core.Container
{
    public interface IServiceRegistry
    {
        TInterface Resolve<TInterface>();
    }
}
