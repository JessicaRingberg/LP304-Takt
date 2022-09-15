namespace LP304_Takt.DTO.UpdateDTOs
{
    public record UserUpdateDto
    {
        public string UserName { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
    }
}
