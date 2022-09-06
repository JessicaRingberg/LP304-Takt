namespace LP304_Takt.Models
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Duration { get; set; }
        public string Reason { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
}
