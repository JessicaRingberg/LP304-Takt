namespace LP304_Takt.DTO.ReadDTO
{
    public record CompanyByUserDto
    {
        public string FirstName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
        public string? Company { get; init; }
    }
}
