using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Threading.Tasks;
using Sharpenchat.Core;
using Sharpenchat.Core.Remoting;
using Sharpenchat.Core.Serialization;
using Sharpenchat.Core.Validation;
using Sharpenchat.Payment.Config;

namespace Sharpenchat.Payment
{
    public abstract class Payment : IPayment
    {
        private readonly PaymentContext _paymentContext;
        private readonly IHttpClient _httpClient;
        private readonly IJsonSerializer _jsonSerializer;
        private readonly IXmlSerializer _xmlSerializer;
        private readonly ISignatureService _signatureService;
        private readonly IValidationProvider _validationProvider;
        private static PaymentConfig _config;

        static Payment() {
            var type = typeof(Payment).GetTypeInfo();
            var resource = $"{type.Namespace}.payment.json";
            _config = Wechat.LoadConfiguration<PaymentConfig>(type.Assembly, resource);
        }

        internal Payment(PaymentContext paymentContext) {
            _paymentContext = paymentContext;
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
        
        public async Task<UnifiedOrderResponse> UnifiedOrderAsync(UnifiedOrderRequest order) {
            if (order == null) {
                throw new ArgumentException("order cannot be null", nameof(order));
            }

            if (order.EmbedTradeType == TradeType.App) {
                if ((order.Detail ?? "").Length > 8192) {
                    throw new ValidationException("detail field cannot exceed 8192 characters");
                }

                if (order.EmbedDetail != null) {
                    foreach (var d in order.EmbedDetail.GoodsDetail) {
                        if (string.IsNullOrEmpty(d.GoodsCategory)) {
                            throw new ValidationException("goods_category is required");
                        }
                        if (string.IsNullOrEmpty(d.Body)) {
                            throw new ValidationException("body is required");
                        }
                    }
                }
            }

            if (order.EmbedTradeType == TradeType.Jsapi) {
                if ((order.Detail ?? "").Length > 6000) {
                    throw new ValidationException("detail field cannot exceed 6000 characters");
                }

                if (order.OpenId == null) {
                    throw new ValidationException($"{nameof(order.OpenId)}is reqiured");
                }
            }

            if (order.EmbedTradeType == TradeType.Native) {
                if ((order.Detail ?? "").Length > 6000) {
                    throw new ValidationException("detail field cannot exceed 6000 characters");
                }
            }

            order.Preparing(_paymentContext);

            _signatureService
                .GenNonce(nonce => { order.NonceStr = nonce; })
                .GenSign(_paymentContext.MchKey, order, sign => { order.Sign = sign; });

            _validationProvider.Validate(order);

            var response = await _httpClient.PostAsync<UnifiedOrderResponse>("api_url", async writer => {
                await _xmlSerializer.SerializeAsync(order, writer);
            });

            return response;
        }
    }
}