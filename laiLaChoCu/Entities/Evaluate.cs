using System.ComponentModel.DataAnnotations;

namespace laiLaChoCu.Entities
{
    public class Evaluate
    {
        public Evaluate(Guid accountId, int itemId, string comment, float score)
        {
            this.AccountId = accountId;
            this.ItemId = itemId;
            this.Comment = comment; 
            this.Score = score;
        }
        [Key]
        public int Id { get; set; }
        public Guid AccountId { get; set; }
        public int ItemId { get; set; }
        public string Comment { get; set; }
        public float Score { get; set; }
        public DateTime Create { get; set; }

    }
}
