using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Services
{
    public interface IUserService
    {
        Task<User?> GetCompanyByUser(int userId);
        Task<UserResponse<string>> DeleteUser(int userId);
        Task<UserResponse<int>> UpdateUser(User user, int userid);
        Task<UserResponse<string>> AddAreaToUser(int userId, int areaId);
        Task<ICollection<User>> GetAllUsers();
        Task<User?> GetUserById(int userid);
        Task<UserResponse<int>> UpdateUserRole(User user, int userId);
    }
}
