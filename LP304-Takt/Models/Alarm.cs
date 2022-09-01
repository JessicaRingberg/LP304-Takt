namespace LP304_Takt.Models
{
    public class Alarm
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Duration { get; set; }
        public string Reason { get; set; }

        public virtual AlarmType AlarmType { get; set; }
        public virtual Order Order { get; set; }

    }
}
