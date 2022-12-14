namespace LP304_Takt.DTO.ReadDto
{
    public record StationDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public bool Andon { get; init; }
        public bool Finished { get; init; }
        public bool Active { get; init; }
    }
}
