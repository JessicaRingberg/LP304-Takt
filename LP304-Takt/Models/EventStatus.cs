namespace LP304_Takt.Models
{
    public class EventStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
