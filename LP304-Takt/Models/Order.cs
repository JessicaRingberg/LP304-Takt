using System.ComponentModel.DataAnnotations;

namespace LP304_Takt.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [Required]
        public double RunSetDec { get; set; }
        [Required]
        public double ChangeSetDec { get; set; }
        [Required]
        public int PartsProd { get; set; }
        [Required]
        public int Backlog { get; set; }
        [Required]
        public int RunSecSet { get; set; }
        [Required]
        public int ChangeSecSet { get; set; }
        [Required]
        public int TaktSet { get; set; }
        [Required]
        public int LastPartProd { get; set; }
        [Required]
        public int Takt { get; set; }
        public int AreaId { get; set; }
        public ICollection<OrderDetails>? OrderDetails { get; set; }
        public ICollection<Event>? Events { get; set; }
        public ICollection<Alarm>? Alarms { get; set; }
        //public int StationId { get; set; }
        //public Station Station { get; set; } = null!;

    }
}
