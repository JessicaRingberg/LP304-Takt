namespace LP304_Takt.DTO.CreateDTO
{
    public record ArticleCreateDto
    {
        public string Name { get; init; } = string.Empty;
        public string ArticleNumber { get; init; } = string.Empty;
    }
}
