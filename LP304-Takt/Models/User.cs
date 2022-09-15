using System.ComponentModel.DataAnnotations;

namespace LP304_Takt.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        public Role Role { get; set; }

    }
}
