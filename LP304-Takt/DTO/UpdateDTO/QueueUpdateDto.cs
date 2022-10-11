using LP304_Takt.DTO.ReadDto;

namespace LP304_Takt.DTO.UpdateDTO
{
    public record QueueUpdateDto
    {
        public ICollection<OrderInQueueDto> Orders { get; init; } = null!;
    }
}
