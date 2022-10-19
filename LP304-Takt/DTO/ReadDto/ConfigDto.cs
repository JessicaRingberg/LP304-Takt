using LP304_Takt.Models;

namespace LP304_Takt.DTO.ReadDto
{
    public record ConfigDto
    {
        public int Id { get; init; }
        public bool LightsOn { get; init; }
        public bool SoundOn { get; init; }
        public int FilterTime { get; init; }
        public string MacBidisp { get; init; } = null!;
        public int AreaId { get; init; }
    }
}
