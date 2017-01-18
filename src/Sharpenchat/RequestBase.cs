using Sharpenchat.Core.Serialization;
using Sharpenchat.Core.Validation;

namespace Sharpenchat
{
    public abstract class RequestBase
    {
        protected readonly IJsonSerializer _jsonSerializer;
        protected readonly IValidationProvider _validationProvider;

        protected RequestBase() {
            _jsonSerializer = Wechat.GetService<IJsonSerializer>();
            _validationProvider = Wechat.GetService<IValidationProvider>();
        }
    }
}