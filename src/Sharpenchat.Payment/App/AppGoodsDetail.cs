using System.ComponentModel.DataAnnotations;

namespace Sharpenchat.Payment
{
    public class AppGoodsDetail:GoodsDetail
    {
        [Required]
        [MaxLength(32)]
        public string goods_category { get; set; }
        [Required]
        [MaxLength(1000)]
        public string body { get; set; }
    }
}