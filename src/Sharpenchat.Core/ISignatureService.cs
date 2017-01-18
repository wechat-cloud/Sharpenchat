using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpenchat.Core
{
    public interface ISignatureService
    {
        void GenSign<T>(T obj, Action<string> callback);
        ISignatureService GenNonce(Action<string> action);
    }
}
