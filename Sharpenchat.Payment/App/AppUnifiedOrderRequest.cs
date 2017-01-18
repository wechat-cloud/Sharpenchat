using System.ComponentModel.DataAnnotations;
using Sharpenchat.Core.Serialization;
using Sharpenchat.Core.Validation;

namespace Sharpenchat.Payment
{
    public class AppUnifiedOrderRequest : UnifiedOrderRequest
    {
        [FieldName("detail")]
        [MaxLength(8192)]
        public string detail;

        public AppUnifiedOrderDetail Detail {
            set {
                if (value == null) {
                    detail = null;
                }

                var jsonSerializer = Payment.GetService<IJsonSerializer>();
                var validationProvider = Payment.GetService<IValidationProvider>();

                validationProvider.Validate(value);

                detail = jsonSerializer.Serialize(value);
            }
        }
    }
}