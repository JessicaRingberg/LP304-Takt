using System.ComponentModel.DataAnnotations;

namespace LP304_Takt.Shared
{
    public class ResetPasswordRequest
    {
        [Required]
        public string Token { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        [Compare("Password")]
        public string PasswordConfirm { get; set; } = string.Empty;
    }
}
