using System.ComponentModel.DataAnnotations;

namespace LP304_Takt.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Area> Areas { get; set; }
    }
}
