using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;
using Newtonsoft.Json;

namespace LP304_Takt.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        //[JsonIgnore]
        //public virtual Company Company { get; set; }


    }

}
