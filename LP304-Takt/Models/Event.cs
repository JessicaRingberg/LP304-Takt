namespace LP304_Takt.Models
{
    public class Event
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Duration { get; set; }
        public string Reason { get; set; }
    }
}
