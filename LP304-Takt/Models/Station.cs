using Newtonsoft.Json;

namespace LP304_Takt.Models
{
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Andon { get; set; }
        public bool Finished { get; set; }
        [JsonIgnore]
        public virtual Area Area { get; set; }
    }
}
