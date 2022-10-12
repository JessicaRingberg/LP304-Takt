
using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Services
{
    public interface IUserService
    {
        Task<Company?> GetCompanyByUser(int userId);
        Task<UserResponse<int>> RegisterUser(User user, string password, int companyId);
        Task<UserResponse<string>> VerifyEmail(string token);
        Task<UserResponse<string>> LoginUser(string email, string password);
        Task<UserResponse<string>> ForgotPassword(string email);
        Task<UserResponse<string>> ResetPassword(ResetPasswordRequest request, string token);
        Task<UserResponse<string>> DeleteUser(int id);
        Task<UserResponse<int>> UpdateUser(User user, int id);
        Task<UserResponse<string>> RefreshToken(string token);
        Task<ICollection<User>> GetAllUsers();
        Task<User?> GetUserById(int id);
    }
}
