using System;
using System.Collections.Generic;
using System.Text;
using Sharpenchat.Core;
using Sharpenchat.Core.Remoting;
using Sharpenchat.Core.Serialization;
using Sharpenchat.Core.Validation;

namespace Sharpenchat.Payment
{
    internal class PaymentContext
    {
        private readonly IHttpClient _httpClient;
        private readonly IJsonSerializer _jsonSerializer;
        private readonly IXmlSerializer _xmlSerializer;
        private readonly ISignatureService _signatureService;
        private readonly IValidationProvider _validationProvider;

        public PaymentContext(
            IHttpClient httpClient,
            IJsonSerializer jsonSerializer,
            IXmlSerializer xmlSerializer,
            ISignatureService signatureService,
            IValidationProvider validationProvider) {
            _httpClient = httpClient;
            _jsonSerializer = jsonSerializer;
            _xmlSerializer = xmlSerializer;
            _signatureService = signatureService;
            _validationProvider = validationProvider;
        }

        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public string MchId { get; set; }
        public string MchKey { get; set; }

        public IHttpClient HttpClient => _httpClient;
        public IJsonSerializer JsonSerializer => _jsonSerializer;
        public IXmlSerializer XmlSerializer => _xmlSerializer;
        public ISignatureService SignatureService => _signatureService;
        public IValidationProvider ValidationProvider => _validationProvider;
    }
}
