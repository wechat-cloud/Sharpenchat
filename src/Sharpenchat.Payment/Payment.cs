using System;
using Sharpenchat.Core.Remoting;
using Sharpenchat.Core.Serialization;

namespace Sharpenchat.Payment
{
    public abstract class Payment : IPayment
    {
        private readonly IHttpClient _httpClient;
        private readonly IJsonSerializer _jsonSerializer;
        private readonly IXmlSerializer _xmlSerializer;

        protected Payment(
            IHttpClient httpClient, 
            IJsonSerializer jsonSerializer, 
            IXmlSerializer xmlSerializer) {
            _httpClient = httpClient;
            _jsonSerializer = jsonSerializer;
            _xmlSerializer = xmlSerializer;
        }

        public void OrderQuery() {
            throw new NotImplementedException();
        }

        public void CloseOrder() {
            throw new NotImplementedException();
        }

        public void Refund() {
            throw new NotImplementedException();
        }

        public void RefundQuery() {
            throw new NotImplementedException();
        }

        public void DownloadBill() {
            throw new NotImplementedException();
        }

        public void Report() {
            throw new NotImplementedException();
        }

        protected TRes ExecuteUnifiedOrderRequest<TReq, TRes>(TReq request)
            where TReq : UnifiedOrderRequest
            where TRes : UnifiedOrderResponse {
            throw new NotImplementedException();
        }
    }
}