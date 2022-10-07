using System.Security.Policy;

namespace LP304_Takt.Models
{
    public class Queue
    {
        public int Id { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
