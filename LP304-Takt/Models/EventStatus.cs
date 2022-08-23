using System.ComponentModel.DataAnnotations;

namespace LP304_Takt.Models
{
    public class EventStatus
    {
        public int Id { get; set; }

        [Key]
        public string Name { get; set; }
    }
}
