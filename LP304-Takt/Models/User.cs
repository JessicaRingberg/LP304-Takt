using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace LP304_Takt.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public virtual Company Company { get; set; }
        [JsonIgnore]
        public virtual Role Role { get; set; }

    }
}
