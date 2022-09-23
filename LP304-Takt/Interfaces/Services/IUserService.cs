
using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Services
{
    public interface IUserService : IBaseService<User>
    {
        Task<Company?> GetCompanyByUser(int userId);
        Task<ServiceResponse<int>> RegisterUser(User user, string password, int companyId);
        Task<ServiceResponse<string>> VerifyEmail(string token);
        Task<ServiceResponse<string>> LoginUser(string email, string password);
        Task<ServiceResponse<string>> ForgotPassword(string email);
        Task<ServiceResponse<string>> ResetPassword(ResetPasswordRequest request);
        Task<ServiceResponse<string>> DeleteUser(int id);
    }
}
