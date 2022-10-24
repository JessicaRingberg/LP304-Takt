using LP304_Takt.Models;

namespace LP304_Takt.DTO.ReadDto
{
    public record OrderDetailsDto
    {
        public int Id { get; init; }
        public int Quantity { get; init; }
        public string? Article { get; init; }
        public int OrderId { get; init; }
    }
}
