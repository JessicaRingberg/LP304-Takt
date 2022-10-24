namespace LP304_Takt.DTO.CreateDTO
{
    public record StationCreateDto
    {
        public string Name { get; init; } = null!;
        public bool Andon { get; init; }
        public bool Finished { get; init; }
        public bool Active { get; init; }
    }
}
