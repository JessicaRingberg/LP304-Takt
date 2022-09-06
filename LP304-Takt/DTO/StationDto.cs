using LP304_Takt.Models;

namespace LP304_Takt.DTO
{
    public record StationDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public ICollection<Order> Orders { get; init; }
    }
}
