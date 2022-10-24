using LP304_Takt.Models;

namespace LP304_Takt.DTO.UpdateDTO
{
    public record UpdateUserRoleDto
    {
        public Role Role { get; init; }
    }
}
