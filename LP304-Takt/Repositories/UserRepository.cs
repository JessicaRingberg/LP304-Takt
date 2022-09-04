using System.Collections;
using LP304_Takt.Models;
using Microsoft.EntityFrameworkCore;

namespace LP304_Takt.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(LP304Context context) : base(context)
        {
        }

        public async Task AddUser(User user, int id)
        {
            var company = await _context.Company.FirstOrDefaultAsync(c => c.Id == id);
            user.Company = company;
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();


        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {//Theninclude to show company areas but not necessary here
            return await _context.User.Include(u => u.Company)
                .ToListAsync() ;
        }
    }
}
