using LP304_Takt.Models;
using LP304_Takt.Shared;
using NuGet.Protocol.Plugins;
using System.Threading.Tasks;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetCompanyByUser(int userId);       
        Task<UserResponse<string>> DeleteUser(int userId);
        Task<UserResponse<int>> UpdateUser(User user, int userId);
        Task<UserResponse<string>> AddAreaToUser(int userId, int areaId);
        Task<ICollection<User>> GetAllUsers();
        Task<User?> GetUserById(int userId);
        Task<UserResponse<int>> ChangeUserRole(User user, int userId);
    }
}
