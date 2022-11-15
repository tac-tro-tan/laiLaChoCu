using System.ComponentModel.DataAnnotations;

namespace laiLaChoCu.Models.Chats
{
    public class MessageRequest
    {
        [Required]
        public Guid IdChat { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
