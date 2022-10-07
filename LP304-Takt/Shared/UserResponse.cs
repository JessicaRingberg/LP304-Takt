namespace LP304_Takt.Shared
{
    public class UserResponse<T> : RefreshToken
    {
        public T? Data { get; set; }

        public bool Success { get; set; } = false;

        public string Message { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string? Role { get; set; }
    }
}
