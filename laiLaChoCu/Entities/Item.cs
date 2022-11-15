using laiLaChoCu.Enums;
using System.ComponentModel.DataAnnotations;

namespace laiLaChoCu.Entities
{
    public class Item
    {
        public Item( Guid accountId, string name, string topic, string area, int price, string address, string phone, string describe, string image)
        {
            this.AccountId = accountId;
            this.Name = name;
            this.Topic = topic;
            this.Area = area;
            this.Price = price;
            this.Address = address;
            this.Phone = phone;
            this.Describe = describe;
            this.Image = image;
        }
        [Key]
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
