
namespace LP304_Takt.DTO
{
    public record CompanyDto
    {
        public int Id { get; init; }
        public string Name { get; init; }

        public ICollection<UserDto> Users { get; set; }
        public ICollection<AreaDto> Areas { get; set; }
    }
}
