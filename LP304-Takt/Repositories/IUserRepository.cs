using System.Collections;
using LP304_Takt.Models;

namespace LP304_Takt.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task AddUser(User user, int id);
        Task<IEnumerable<User>> GetAllUsers();
    }
}
