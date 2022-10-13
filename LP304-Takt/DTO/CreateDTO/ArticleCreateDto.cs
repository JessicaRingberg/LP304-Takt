namespace LP304_Takt.DTO.CreateDTO
{
    public record ArticleCreateDto
    {
        public string Name { get; init; } = null!;
        public string ArticleNumber { get; init; } = null!;
    }
}
