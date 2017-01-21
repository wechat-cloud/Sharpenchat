using System;

namespace Sharpenchat.Core
{
    public interface ISignatureService
    {
        void GenSign<T>(string key, T obj, Action<string> onSign);
        void GenSign<T>(string key, T obj, SignatureType signatureType, Action<string> onSign);
        ISignatureService GenNonce(Action<string> onNonce);
    }
}