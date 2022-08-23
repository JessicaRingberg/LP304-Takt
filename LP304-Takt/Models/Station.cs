namespace LP304_Takt.Models
{
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Area Area { get; set; }
    }
}
