namespace LP304_Takt.DTO.UpdateDTO
{
    public record ArticleUpdateDto
    {
        public string Name { get; init; } = null!;
        public string ArticleNumber { get; init; } = null!;
    }
}
