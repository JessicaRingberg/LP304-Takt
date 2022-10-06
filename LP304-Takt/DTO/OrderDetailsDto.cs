using LP304_Takt.Models;

namespace LP304_Takt.DTO
{
    public record OrderDetailsDto
    {
        public Order Order { get; init; } = null!;
        public Article Article { get; init; } = null!;
        public int Quantity { get; init; }
    }
}
