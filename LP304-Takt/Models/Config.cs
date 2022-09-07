using System.ComponentModel.DataAnnotations;

namespace LP304_Takt.Models
{
    public class Config
    {
        public int Id { get; set; }
        public bool LightsOn { get; set; }
        public bool SoundOn { get; set; }
        [Required]
        public int FilterTime { get; set; }
        [Required]
        public string MacBidisp { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
    }
}
