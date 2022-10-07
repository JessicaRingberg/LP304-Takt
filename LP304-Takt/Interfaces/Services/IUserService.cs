
using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Services
{
    public interface IUserService : IBaseService<User>
    {
        Task<Company?> GetCompanyByUser(int userId);
        Task<UserResponse<int>> RegisterUser(User user, string password, int companyId);
        Task<UserResponse<string>> VerifyEmail(string token);
        Task<UserResponse<string>> LoginUser(string email, string password);
        Task<UserResponse<string>> ForgotPassword(string email);
        Task<UserResponse<string>> ResetPassword(ResetPasswordRequest request);
        Task<UserResponse<string>> DeleteUser(int id);
        Task<UserResponse<string>> RefreshToken(string token);
    }
}
