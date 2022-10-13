using LP304_Takt.Models;

namespace LP304_Takt.DTO.ReadDto
{
    public record UserDto
    {
        public int Id { get; init; }
        public string FirstName { get; init; } = null!;
        public string LastName { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string Role { get; init; } = null!;

    }

}
