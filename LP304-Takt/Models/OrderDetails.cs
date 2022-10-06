namespace LP304_Takt.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public Order Order { get; set; } = null!;
        public Article Article { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
