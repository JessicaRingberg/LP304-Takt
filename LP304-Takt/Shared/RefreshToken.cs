namespace LP304_Takt.Shared
{
    public class RefreshToken
    {
        public string Token { get; set; } = null!;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Expires { get; set; }
    }
}
