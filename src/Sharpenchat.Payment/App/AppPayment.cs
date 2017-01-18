using System;
using Sharpenchat.Core;
using Sharpenchat.Core.Remoting;
using Sharpenchat.Core.Serialization;

namespace Sharpenchat.Payment
{
    public class AppPayment : Payment, IAppPayment
    {
        public AppPayment(
            IHttpClient httpClient, 
            IJsonSerializer jsonSerializer, 
            IXmlSerializer xmlSerializer,
            ISignatureService signatureService) 
            : base(httpClient, jsonSerializer, xmlSerializer, signatureService) {}

        public void UnifiedOrder() {
            throw new NotImplementedException();
        }
    }
}