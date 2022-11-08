using System.ComponentModel.DataAnnotations;

namespace laiLaChoCu.Entities
{
    public class Cart
    {
        public Cart(Guid accountId,int itemId)
        {
            this.AccountId = accountId;
            this.ItemId = itemId;
        }
        [Key]
        public int Id { get; set; }
        public Guid AccountId { get; set; }
        public int ItemId { get; set; }
        public DateTime Create { get; set; }
    }
}
