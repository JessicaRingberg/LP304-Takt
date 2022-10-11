namespace LP304_Takt.DTO.ReadDto
{
    public record QueueDto
    {
        public int Id { get; init; }
        public ICollection<OrderDto> Orders { get; init; } = null!;
    }
}
