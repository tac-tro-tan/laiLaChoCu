using System.ComponentModel.DataAnnotations;

namespace laiLaChoCu.Models.Items
{
    public class CartRequet
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public int page { get; set; }
        [Required]
        public int pageSize { get; set; }
    }
}
