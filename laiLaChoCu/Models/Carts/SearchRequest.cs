using System.ComponentModel.DataAnnotations;

namespace laiLaChoCu.Models.Carts
{
    public class SearchRequest
    {
        [Required]
        public Guid AccountId { get; set; }
        [Required]
        public int page { get; set; }
        [Required]
        public int pageSize { get; set; }   
    }
}
