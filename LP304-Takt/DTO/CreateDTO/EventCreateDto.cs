namespace LP304_Takt.DTO.CreateDTO
{
    public record EventCreateDto
    {
        public DateTime StartTime { get; init; }
        public DateTime EndTime { get; init; }
        public int Duration { get; init; }
        public string Reason { get; init; } = null!;
    }
}
