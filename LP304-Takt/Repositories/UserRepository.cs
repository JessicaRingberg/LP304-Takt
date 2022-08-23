using System.Collections;
using LP304_Takt.Models;

namespace LP304_Takt.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(LP304Context context) : base(context)
        {
        }

        public IEnumerable<User> GetUsers(int count)
        {
            return _context.User.OrderByDescending(u => u.Id).Take(count).ToList();
        }
    }
}
