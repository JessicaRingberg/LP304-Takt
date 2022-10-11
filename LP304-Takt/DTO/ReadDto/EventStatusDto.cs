using LP304_Takt.Models;

namespace LP304_Takt.DTO.ReadDto
{
    public class EventStatusDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        //public ICollection<EventDto> Events { get; set; } = null!;
    }
}
