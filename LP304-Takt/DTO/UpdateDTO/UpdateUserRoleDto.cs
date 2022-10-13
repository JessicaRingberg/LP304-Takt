using LP304_Takt.Shared;

namespace LP304_Takt.DTO.UpdateDTO
{
    public record UpdateUserRoleDto
    {
        public Role Role { get; init; }
    }
}
