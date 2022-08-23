namespace LP304_Takt.Models
{
    public class Queue
    {

        public int Id { get; set; }
        public virtual Order Order { get; set; }
    }
}
