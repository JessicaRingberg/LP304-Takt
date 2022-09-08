using LP304_Takt.Models;

namespace LP304_Takt.DTO
{
    public class AlarmTypeDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public ICollection<AlarmDto> Alarms { get; init; }
    }
}
