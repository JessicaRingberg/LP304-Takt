using Newtonsoft.Json;

namespace LP304_Takt.Models
{
    public class Alarm
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Duration { get; set; }
        public string Reason { get; set; }
        [JsonIgnore]
        public virtual AlarmType AlarmType { get; set; }
        [JsonIgnore]
        public virtual Order Order { get; set; }

    }
}
