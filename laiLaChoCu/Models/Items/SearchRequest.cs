using System.ComponentModel.DataAnnotations;

namespace laiLaChoCu.Models.Items
{
    public class SearchRequest
    {
        [Required]
        public string keyWord { get; set; }
        [Required]
        public int page { get; set; }
        [Required]
        public int pageSize { get; set; }
    }
}
