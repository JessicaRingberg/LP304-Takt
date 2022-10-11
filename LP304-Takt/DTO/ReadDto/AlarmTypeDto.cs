using LP304_Takt.Models;

namespace LP304_Takt.DTO.ReadDto
{
    public class AlarmTypeDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        //public ICollection<AlarmDto> Alarms { get; init; } = null!;
    }
}
