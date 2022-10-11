namespace LP304_Takt.DTO.ReadDto
{
    public record CompanyDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public ICollection<UserDto> Users { get; init; } = null!;
        public ICollection<AreaDto> Areas { get; init; } = null!;
    }
}
