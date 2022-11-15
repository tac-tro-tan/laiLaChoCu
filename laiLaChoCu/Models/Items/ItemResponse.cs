using laiLaChoCu.Enums;

namespace laiLaChoCu.Models.Items
{
    public class ItemResponse
    {
        public int Id { get; set; }
        public Guid AccountId { get; set; }
        public string Name { get; set; }
        public string Topic { get; set; }
        public string Area { get; set; }
        public int Price { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Describe { get; set; }
        public StatusEnum Status { get; set; }
        public string Image { get; set; }
    }
}
