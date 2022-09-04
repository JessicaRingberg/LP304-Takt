using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LP304_Takt.Models
{
    public class Company
    {
        public Company()
        {
            Areas = new List<Area>();
        }
        public int Id { get; set; }

        public string? Name { get; set; }

        //[JsonIgnore]
        public ICollection<Area> Areas { get; set; }
    }
}
