using System.ComponentModel.DataAnnotations;

namespace LP304_Takt.Models
{
    public class EventStatus
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public ICollection<Event>? Events { get; set; }
    }
}
