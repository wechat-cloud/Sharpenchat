using System;
using Sharpenchat.Core.Remoting;
using Sharpenchat.Core.Serialization;

namespace Sharpenchat.Payment
{
    public class AppPayment : Payment, IAppPayment
    {
        public AppPayment(IHttpClient httpClient, IJsonSerializer jsonSerializer, IXmlSerializer xmlSerializer) : base(httpClient, jsonSerializer, xmlSerializer) {}

        public void UnifiedOrder() {
            throw new NotImplementedException();
        }
    }
}