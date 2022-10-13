namespace LP304_Takt.DTO.ReadDto
{
    public record EventDto
    {
        public int Id { get; init; }
        public DateTime StartTime { get; init; }
        public DateTime EndTime { get; init; }
        public int Duration { get; init; }
        public string Reason { get; init; } = null!;
        public string? EventStatus { get; init; }


    }
}
