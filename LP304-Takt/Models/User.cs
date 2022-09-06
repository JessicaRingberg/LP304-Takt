using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace LP304_Takt.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}
