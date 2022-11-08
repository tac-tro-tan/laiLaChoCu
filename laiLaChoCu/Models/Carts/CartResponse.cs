namespace laiLaChoCu.Models.Carts
{
    public class CartResponse
    {
        public int Id { get; set; }
        public Guid AccountId { get; set; }
        public int ItemId { get; set; }
        public DateTime Create { get; set; }
    }
}
