using System.ComponentModel.DataAnnotations;

namespace laiLaChoCu.Entities
{
    public class Feedback
    {
        public Feedback( Guid accountId, string title, string content)
        {
            this.AccountId = accountId;
            this.Title = title;
            this.Content = content;
        }

        [Key]
        public int Id { get; set; }
        public Guid AccountId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
