namespace LP304_Takt.Models
{
    public class Config
    {
        public int Id { get; set; }
        public bool LightsOn { get; set; }
        public bool SoundOn { get; set; }
        public int FilterTime { get; set; }

        public virtual Area Area { get; set; }
        public virtual Mac Mac { get; set; }
    }
}
