using System.ComponentModel.DataAnnotations;

namespace laiLaChoCu.Models.Chats
{
    public class ChatRequest
    {
        [Required]
        public Guid AccountId1 { get; set; }
        [Required]
        public Guid AccountId2 { get; set; }
    }
}
