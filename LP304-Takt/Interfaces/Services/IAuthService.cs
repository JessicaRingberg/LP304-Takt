using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Services
{
    public interface IAuthService
    {
        Task<bool> UserAlreadyExists(string userName);
        Task<UserResponse<int>> RegisterUser(User user, string email, int companyId);
        Task<UserResponse<string>> VerifyEmail(string verificationToken);
        Task<UserResponse<string>> Login(string email, string password);
        Task<UserResponse<string>> ForgotPassword(string email);
        Task<UserResponse<string>> ResetPassword(ResetPasswordRequest request, string passwordResetToken);
        Task<UserResponse<string>> RefreshToken(string refreshToken);
    }
}
