using LP304_Takt.Models;

namespace LP304_Takt.DTO
{
    public record StationDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public bool Andon { get; init; }
        public bool Finished { get; init; }

    }
}
