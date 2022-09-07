

namespace LP304_Takt.DTO
{
    public record UserDto 
    {
        public int Id { get; init; }
        public string UserName { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string Role { get; init; }

    }

}
