namespace LP304_Takt.DTO.CreateDTO
{
    public record StationCreateDto
    {
        public string Name { get; init; } = string.Empty;
        public bool Andon { get; init; }
        public bool Finished { get; init; }
    }
}
