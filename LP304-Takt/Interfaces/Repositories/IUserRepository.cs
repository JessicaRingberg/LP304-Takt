using LP304_Takt.Models;
using LP304_Takt.Shared;
using NuGet.Protocol.Plugins;
using System.Threading.Tasks;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<Company?> GetCompanyByUser(int userId);
        Task<bool> UserAlreadyExists(string userName);
        Task<UserResponse<int>> RegisterUser(User user, string email, int companyId);
        Task<UserResponse<string>> VerifyEmail(string token);
        Task<UserResponse<string>> Login(string email, string passWord);
        Task<UserResponse<string>> ForgotPassword(string email);
        Task<UserResponse<string>> ResetPassword(ResetPasswordRequest request);
        Task<UserResponse<string>> DeleteUser(int id);
        Task<UserResponse<int>> UpdateUser(User user, int id);
        Task<UserResponse<string>> RefreshToken(string token);
        Task<ICollection<User>> GetAllUsers();
        Task<User?> GetUserById(int id);
    }
}
