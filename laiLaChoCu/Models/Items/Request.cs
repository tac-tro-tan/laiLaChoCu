using System.ComponentModel.DataAnnotations;

namespace laiLaChoCu.Models.Items
{
    public class Request
    {
        
        [Required]
        public int page { get; set; }
        [Required]
        public int pageSize { get; set; }
    }
}
