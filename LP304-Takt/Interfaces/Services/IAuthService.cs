using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Services
{
    public interface IAuthService
    {
        Task<bool> UserAlreadyExists(string userName);
        Task<UserResponse<int>> RegisterUser(User user, string email, int companyId);
        Task<UserResponse<string>> VerifyEmail(string token);
        Task<UserResponse<string>> Login(string email, string passWord);
        Task<UserResponse<string>> ForgotPassword(string email);
        Task<UserResponse<string>> ResetPassword(ResetPasswordRequest request, string token);
        Task<UserResponse<string>> RefreshToken(string token);
    }
}
