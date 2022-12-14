using System.ComponentModel.DataAnnotations;

namespace LP304_Takt.Models
{
    public class Station
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public bool Andon { get; set; }
        public bool Finished { get; set; }
        public bool Active { get; set; }
        public int AreaId { get; set; }
    }
}
