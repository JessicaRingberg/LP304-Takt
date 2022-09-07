using LP304_Takt.Models;

namespace LP304_Takt.DTO
{
    public record StationDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public bool Andon { get; init; }
        public bool Finished { get; init; }
        public ICollection<OrderDto> Orders { get; init; }
    }
}
