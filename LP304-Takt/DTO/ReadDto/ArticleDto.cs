namespace LP304_Takt.DTO.ReadDto
{
    public record ArticleDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public string ArticleNumber { get; init; } = null!;
    }
}
