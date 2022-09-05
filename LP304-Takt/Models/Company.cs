using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LP304_Takt.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Area> Areas { get; set; }
    }
}
