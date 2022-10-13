using System.ComponentModel.DataAnnotations;

namespace LP304_Takt.Shared
{
    public class ResetPasswordRequest
    {
        public string Password { get; set; } = null!;
        [Compare("Password")]
        public string PasswordConfirm { get; set; } = null!;
    }
}
