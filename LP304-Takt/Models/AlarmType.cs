using System.ComponentModel.DataAnnotations;

namespace LP304_Takt.Models
{
    public class AlarmType
    {
        //public AlarmType()
        //{
        //    Alarms = new List<Alarm>();
        //}
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public ICollection<Alarm> Alarms { get; set; } = null!;
    }
}
