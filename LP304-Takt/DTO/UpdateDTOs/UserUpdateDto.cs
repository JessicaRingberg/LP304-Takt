namespace LP304_Takt.DTO.UpdateDTOs
{
    public record UserUpdateDto
    {
        public string UserName { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
    }
}
