using System.ComponentModel.DataAnnotations;

namespace LP304_Takt.Models
{
    public class Station
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
