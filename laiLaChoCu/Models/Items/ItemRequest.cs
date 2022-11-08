using System.ComponentModel.DataAnnotations;

namespace laiLaChoCu.Models.Items
{
    public class ItemRequest
    {
        [Required]
        public Guid AccountId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Topic { get; set; }
        [Required]
        public string Area { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public string Describe { get; set; }
    }
}
