using LP304_Takt.DTO.ReadDto;

namespace LP304_Takt.DTO.ReadDTO
{
    public record OrderEventsDto
    {
        public ICollection<EventDto> Events { get; init; } = null!;
    }
}
