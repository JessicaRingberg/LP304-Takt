namespace LP304_Takt.DTO.UpdateDTOs
{
    public record UserUpdateDto
    {
        public string FirstName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
    }
}
