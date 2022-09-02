using Newtonsoft.Json;

namespace LP304_Takt.Models
{
    public class Queue
    {

        public int Id { get; set; }
        [JsonIgnore]
        public virtual Order Order { get; set; }
    }
}
