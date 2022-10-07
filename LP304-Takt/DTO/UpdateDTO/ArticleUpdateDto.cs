namespace LP304_Takt.DTO.UpdateDTO
{
    public record ArticleUpdateDto
    {
        public string Name { get; init; } = string.Empty;
        public string ArticleNumber { get; init; } = string.Empty;
    }
}
