namespace LP304_Takt.DTO
{
    public record ConfigCreateDto
    {
        public bool LightsOn { get; set; }
        public bool SoundOn { get; set; }
        public int FilterTime { get; set; }
        public string MacBidisp { get; set; }
    }
}
