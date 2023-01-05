using System.ComponentModel.DataAnnotations;

namespace laiLaChoCu.Models.Evaluate
{
    public class EvaluateRequest
    {
        [Required]
        public Guid AccountId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public float Score { get; set; }
    }
}
