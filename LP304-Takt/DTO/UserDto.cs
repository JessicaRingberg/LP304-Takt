

using LP304_Takt.Models;

namespace LP304_Takt.DTO
{
    public record UserDto 
    {
        public int Id { get; init; }
        public string UserName { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
        //public Role Role { get; init; }

    }

}
