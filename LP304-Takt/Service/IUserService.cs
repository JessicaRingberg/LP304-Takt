using LP304_Takt.Models;

namespace LP304_Takt.Service
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetOneUser(int id);
        Task AddUser(User user);
        Task RemoveUser(User user);
        Task<User> UpdateUser(User user);
    }
}
