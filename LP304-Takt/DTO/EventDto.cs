namespace LP304_Takt.DTO
{
    public record EventDto
    {
        public int Id { get; init; }
        public DateTime StartTime { get; init; }
        public DateTime EndTime { get; init; }
        public int Duration { get; init; }
        public string Reason { get; init; }

        //public ICollection<EventStatusDto> EventStatuses { get; init; }
    }
}
