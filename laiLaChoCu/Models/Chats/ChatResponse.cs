using laiLaChoCu.Entities;

namespace laiLaChoCu.Models.Chats
{
    public class ChatResponse
    {
        public int Id { get; set; }
        public Guid AccountId1 { get; set; }
        public Guid AccountId2 { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public List<Message> Messages { get; set; }
    }
}
