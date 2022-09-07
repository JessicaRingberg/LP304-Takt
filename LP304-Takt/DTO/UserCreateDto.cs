namespace LP304_Takt.DTO
{
    public record UserCreateDto
    {
        public string UserName { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
    }
}
