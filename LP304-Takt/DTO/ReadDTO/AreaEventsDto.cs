using LP304_Takt.DTO.ReadDto;

namespace LP304_Takt.DTO.ReadDTO
{
    public class AreaEventsDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public ICollection<OrderEventsDto> Orders { get; init; } = null!;
    }
}
