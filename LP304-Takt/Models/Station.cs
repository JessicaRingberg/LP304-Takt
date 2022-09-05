using Newtonsoft.Json;

namespace LP304_Takt.Models
{
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int AreaId { get; set; }
        public Area Area { get; set; }
    }
}
