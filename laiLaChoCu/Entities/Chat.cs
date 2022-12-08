using laiLaChoCu.Enums;

namespace laiLaChoCu.Entities
{
    public class Chat
    {
        public Chat( Guid accountId1, Guid accountId2)
        {
            this.AccountId1 = accountId1;
            this.AccountId2 = accountId2;
        }

        public int Id { get; set; }
        public Guid AccountId1 { get; set; }
        public Guid AccountId2 { get; set; }
        public string Name1 { get; set; }   
        public string Name2 { get; set; }
        public StatusEnum Status { get; set; }
        public List<Message> Messages { get; set; }
    }
}
