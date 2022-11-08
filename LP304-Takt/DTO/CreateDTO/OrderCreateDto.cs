namespace LP304_Takt.DTO.CreateDTO
{
    public record OrderCreateDto
    {
        //public DateTime StartTime { get; init; }
        public double RunSetDec { get; init; }
        public double ChangeSetDec { get; init; }
        public int PartsProd { get; init; }
        public int Backlog { get; init; }
        public int RunSecSet { get; init; }
        public int ChangeSecSet { get; init; }
        public int TaktSet { get; init; }
        public int LastPartProd { get; init; }
        public int Takt { get; init; }
    }
}
