using LP304_Takt.DTO.ReadDto;
using LP304_Takt.Models;

namespace LP304_Takt.DTO.ReadDTO
{
    public record AreaByUserDto
    {
        public int? Id { get; init; }
        public string? Name { get; init; }
    }
}
