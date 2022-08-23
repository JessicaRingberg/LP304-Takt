using System.Collections;
using LP304_Takt.Models;

namespace LP304_Takt.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        IEnumerable<User> GetUsers(int count);
    }
}
