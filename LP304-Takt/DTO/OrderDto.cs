using LP304_Takt.Models;

namespace LP304_Takt.DTO
{
    public record OrderDto
    {
        public int Id { get; init; }
        public DateTime StartTime { get; init; }
        public DateTime EndTime { get; init; }
        public int Quantity { get; init; }
        public double RunSetDec { get; init; }
        public double ChangeSetDec { get; init; }
        public int PartsProd { get; init; }
        public int Backlog { get; init; }
        public int RunSecSet { get; init; }
        public int ChangeSecSet { get; init; }
        public int TaktSet { get; init; }
        public int LastPartProd { get; init; }
        public int Takt { get; init; }

        public int StationId { get; init; }
        public ICollection<OrderDetailsDto> OrderDetails { get; init; } = null!;
        public ICollection<AlarmDto> Alarms { get; init; } = null!;
        public ICollection<EventDto> Events { get; init; } = null!;
    }
}
