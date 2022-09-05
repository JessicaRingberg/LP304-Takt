
namespace LP304_Takt.DTO
{
    public record AreaDto
    {
        public int Id { get; init; }
        public string Name { get; init; }

        public ICollection<StationDto> Stations { get; init; }
    }
}
