using System.ComponentModel.DataAnnotations;

namespace LP304_Takt.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public ICollection<User> Users { get; set; } = null!;
        public ICollection<Area> Areas { get; set; } = null!;
    }
}
