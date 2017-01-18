using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpenchat.Core.Validation
{
    public interface IValidationProvider
    {
        void Validate<T>(T value);
    }
}
