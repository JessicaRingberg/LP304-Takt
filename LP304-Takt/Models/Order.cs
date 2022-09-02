using Newtonsoft.Json;

namespace LP304_Takt.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int Quantity { get; set; }
        public double RunSetDec { get; set; }
        public double ChangeSetDec { get; set; }
        public int PartsProd { get; set; }
        public int Backlog { get; set; }
        public int RunSecSet { get; set; }
        public int ChangeSetSec { get; set; }
        public int TaktSet { get; set; }
        public int LastPartProd { get; set; }
        public int Takt { get; set; }
        [JsonIgnore]
        public virtual Station Station { get; set; }

    }
}
