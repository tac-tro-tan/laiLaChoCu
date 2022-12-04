using System.ComponentModel.DataAnnotations;

namespace laiLaChoCu.Models.Items
{
    public class PriceRequest
    {
        [Required]
        public int Price1 { get; set; }
        [Required]
        public int Price2 { get; set; }
        [Required]
        public int page { get; set; }
        [Required]
        public int pageSize { get; set; }
    }
}
