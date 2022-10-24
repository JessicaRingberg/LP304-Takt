namespace LP304_Takt.DTO
{
    public record StationUpdateDto
    {
        public string Name { get; init; } = string.Empty;
        public bool Active { get; init; }
    }
}
