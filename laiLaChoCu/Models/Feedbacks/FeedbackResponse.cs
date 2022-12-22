using laiLaChoCu.Enums;

namespace laiLaChoCu.Models.Feedbacks
{
    public class FeedbackResponse
    {
        public int Id { get; set; }
        public Guid AccountId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public StatusEnum Status { get; set; }
    }
}
