using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;
using Newtonsoft.Json;

namespace LP304_Takt.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<Station> Stations { get; set; }
    }

}
