namespace LP304_Takt.DTO
{
    public record RoleDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public ICollection<UserDto> Users { get; init; }
    }
}
