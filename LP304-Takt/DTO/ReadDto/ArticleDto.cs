namespace LP304_Takt.DTO.ReadDto
{
    public record ArticleDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string ArticleNumber { get; init; } = string.Empty;
    }
}
