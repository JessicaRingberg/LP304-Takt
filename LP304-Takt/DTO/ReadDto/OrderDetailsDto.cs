using LP304_Takt.Models;

namespace LP304_Takt.DTO.ReadDto
{
    public record OrderDetailsDto
    {
        //public Order Order { get; init; } = null!;
        //public Article Article { get; init; } = null!;
        public int Id { get; init; }
        public int Quantity { get; init; }
        public string? Article { get; init; }
        public int OrderId { get; init; }
    }
}
