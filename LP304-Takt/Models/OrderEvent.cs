using System.Collections;

namespace LP304_Takt.Models
{
    public class OrderEvent
    {
        public int Id { get; set; }
        public ICollection<Order> OrderId { get; set; }
        public ICollection<Event> EventId { get; set; }

    }
}
