namespace LP304_Takt.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int ArticleId { get; set; }
        public Article? Article { get; set; } = null!;
    }
}
