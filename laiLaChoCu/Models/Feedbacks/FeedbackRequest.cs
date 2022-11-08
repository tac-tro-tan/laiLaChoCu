namespace laiLaChoCu.Models.Feedbacks
{
    public class FeedbackRequest
    {
        public Guid AccountId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
