using LP304_Takt.DTO;

namespace LP304_Takt.Shared
{
    public class ServiceResponse<T> : RefreshToken
    {
        public T? Data { get; set; }

        public bool Success { get; set; } = false;

        public string Message { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string? Role { get; set; }
        
        
    }
}
