using System.ComponentModel.DataAnnotations;

namespace LP304_Takt.Shared
{
    public class UserRegister
    {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required, StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = null!;
        [Compare("Password")]
        public string PasswordConfirm { get; set; } = null!;
    }
}
