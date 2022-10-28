using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Services
{
    public interface IUserService
    {
        Task<User?> GetCompanyByUser(int userId);
        Task<UserResponse<string>> DeleteUser(int id);
        Task<UserResponse<int>> UpdateUser(User user, int id);
        Task<UserResponse<string>> AddAreaToUser(int userId, int areaId);
        Task<ICollection<User>> GetAllUsers();
        Task<User?> GetUserById(int id);
        Task<UserResponse<int>> UpdateUserRole(User user, int userId);
    }
}
