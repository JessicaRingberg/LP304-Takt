using LP304_Takt.DTO.ReadDto;

namespace LP304_Takt.Shared
{
    public class UserResponse<T>
    {
       // public T? Data { get; set; }

        public bool Success { get; set; } = false;

        public string Message { get; set; } = string.Empty;
        ////public int UserId { get; set; }
        public string JWT { get; set; }
        public UserDto User { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
