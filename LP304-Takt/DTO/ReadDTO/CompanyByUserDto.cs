namespace LP304_Takt.DTO.ReadDTO
{
    public record CompanyByUserDto
    {
        public string FirstName { get; init; } = null!;
        public string LastName { get; init; } = null!;
        public string? Company { get; init; }
    }
}
