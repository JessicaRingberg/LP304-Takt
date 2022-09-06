namespace LP304_Takt.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Quantity { get; set; }
        public double RunSetDec { get; set; }
        public double ChangeSetDec { get; set; }
        public int PartsProd { get; set; }
        public int Backlog { get; set; }
        public int RunSecSet { get; set; }
        public int ChangeSecSet { get; set; }
        public int TaktSet { get; set; }
        public int LastPartProd { get; set; }
        public int Takt { get; set; }
        public int StationId { get; set; }
        public Station Station { get; set; }
        public ICollection<Event> Events { get; set; }

    }
}
