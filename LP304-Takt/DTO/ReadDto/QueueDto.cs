namespace LP304_Takt.DTO.ReadDto
{
    public record QueueDto
    {
        public int Id { get; init; }
        public List<OrderInQueueDto> Orders { get; init; } = null!;
    }
}
