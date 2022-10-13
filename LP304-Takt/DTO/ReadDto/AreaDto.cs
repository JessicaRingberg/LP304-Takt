namespace LP304_Takt.DTO.ReadDto
{
    public record AreaDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public ICollection<StationDto> Stations { get; init; } = null!;
    }
}
