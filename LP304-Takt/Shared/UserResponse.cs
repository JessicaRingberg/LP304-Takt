using LP304_Takt.DTO.ReadDto;

namespace LP304_Takt.Shared
{
    public class UserResponse<T>
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = null!;
        public string JWT { get; set; } = null!;
        public UserDto User { get; set; } = null!;
        public RefreshToken RefreshToken { get; set; } = null!;
    }
}
