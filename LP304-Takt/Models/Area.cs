namespace LP304_Takt.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Company Company{ get; set; }

    }
    
}
