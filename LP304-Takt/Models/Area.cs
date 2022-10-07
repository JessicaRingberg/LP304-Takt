using System.ComponentModel.DataAnnotations;

namespace LP304_Takt.Models
{
    public class Area
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
        public Config? Config { get; set; }
        public Queue? Queue { get; set; }
        public ICollection<Order> Orders { get; set; } = null!;
        public ICollection<Station> Stations { get; set; } = null!;
    }

}
