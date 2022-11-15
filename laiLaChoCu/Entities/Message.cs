using Microsoft.EntityFrameworkCore;

namespace laiLaChoCu.Entities
{
    [Owned]
    public class Message
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public Chat Chat { get; set; }
    }
}
