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
                
                _validationProvider.Validate(value);

                detail = _jsonSerializer.Serialize(value);
            }
        }
    }
}