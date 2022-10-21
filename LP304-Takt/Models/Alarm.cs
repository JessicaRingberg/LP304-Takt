using System.ComponentModel.DataAnnotations;

namespace LP304_Takt.Models
{
    public class Alarm
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public string Reason { get; set; } = null!;
        public int OrderId { get; set; }
        //public Order Order { get; set; } = null!;
        public int AlarmTypeId { get; set; }
        public AlarmType? AlarmType { get; set; }

    }
}
