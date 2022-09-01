using System.ComponentModel.DataAnnotations.Schema;

namespace LP304_Takt.Models
{
    public class Company
    {
        
        public int Id { get; set; }

        public string? Name { get; set; }
        //public ICollection<Area> Areas { get; set; } = new List<Area>();
    }
}
