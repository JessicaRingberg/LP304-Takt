
namespace LP304_Takt.DTO
{
    public record AreaDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public ICollection<StationDto> Stations { get; init; }
    }
}
