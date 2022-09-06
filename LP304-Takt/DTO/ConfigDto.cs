using LP304_Takt.Models;

namespace LP304_Takt.DTO
{
    public record ConfigDto
    {
        public int Id { get; set; }
        public bool LightsOn { get; set; }
        public bool SoundOn { get; set; }
        public int FilterTime { get; set; }
        public string MacBidisp { get; set; }
        //public Area Area { get; set; }
    }
}
