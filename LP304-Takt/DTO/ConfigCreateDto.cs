namespace LP304_Takt.DTO
{
    public record ConfigCreateDto
    {
        public bool LightsOn { get; init; }
        public bool SoundOn { get; init; }
        public int FilterTime { get; init; }
        public string MacBidisp { get; init; } = string.Empty;
    }
}
