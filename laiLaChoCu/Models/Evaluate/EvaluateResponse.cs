namespace laiLaChoCu.Models.Evaluate
{
    public class EvaluateResponse
    {
        public int Id { get; set; }
        public Guid AccountId { get; set; }
        public int ItemId { get; set; }
        public string Comment { get; set; }
        public float Score { get; set; }
        public DateTime Create { get; set; }
    }
}
