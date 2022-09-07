using System.ComponentModel.DataAnnotations;

namespace LP304_Takt.Models
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "DefaultUser";
        public ICollection<User> Users { get; set; }
    }
}
