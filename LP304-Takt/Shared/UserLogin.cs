using System.ComponentModel.DataAnnotations;

namespace LP304_Takt.Shared
{
    public class UserLogin
    {
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
