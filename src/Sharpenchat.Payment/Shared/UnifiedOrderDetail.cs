using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sharpenchat.Core.Serialization;

namespace Sharpenchat.Payment
{
    public class UnifiedOrderDetail<T> where T : GoodsDetail
    {
        [Required]
        [FieldName("goods_detail")]
        public IList<T> goods_detail { get; set; }
    }
}