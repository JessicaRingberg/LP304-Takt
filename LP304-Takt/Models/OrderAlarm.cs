using System.Collections;

namespace LP304_Takt.Models
{
    public class OrderAlarm
    {
        public int Id { get; set; }
        public ICollection<Order> OrderId { get; set; }
        public ICollection<Alarm> AlarmId { get; set; }
    }
}
