using System;
using System.Reflection;
using System.Threading.Tasks;
using Sharpenchat.Core;
using Sharpenchat.Core.Remoting;
using Sharpenchat.Core.Serialization;
using Sharpenchat.Payment.Config;

namespace Sharpenchat.Payment
{
    public abstract class Payment : IPayment
    {
        private readonly IHttpClient _httpClient;
        private readonly IJsonSerializer _jsonSerializer;
        private readonly IXmlSerializer _xmlSerializer;
        private readonly ISignatureService _signatureService;
        private static PaymentConfig _config;

        static Payment() {
            var type = typeof(Payment).GetTypeInfo();
            var resource = type.Namespace + "." + "payment.json";
            _config = Wechat.LoadConfiguration<PaymentConfig>(type.Assembly, resource);
        }

        protected Payment(
            IHttpClient httpClient, 
            IJsonSerializer jsonSerializer, 
            IXmlSerializer xmlSerializer,
            ISignatureService signatureService) {
            _httpClient = httpClient;
            _jsonSerializer = jsonSerializer;
            _xmlSerializer = xmlSerializer;
            _signatureService = signatureService;
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

        protected async Task<UnifiedOrderResponse> ExecuteUnifiedOrderRequest<TReq>(TReq request)
            where TReq : UnifiedOrderRequest {

            _signatureService
                .GenNonce(nonce => {
                    request.nonce_str = nonce;
                })
                .GenSign(request, sign => {
                    request.sign = sign;
                });

            var response = await _httpClient.PostAsync<UnifiedOrderResponse>("api_url", async writer => {
                await _xmlSerializer.SerializeAsync(request, writer);
            });

            return response;
        }
    }
}