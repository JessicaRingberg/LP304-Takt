using System.Collections;
using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using Microsoft.EntityFrameworkCore;

namespace LP304_Takt.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(User user, int companyId)
        {
            var company = await _context.Companies.FindAsync(companyId);
            var role = await _context.Roles.FindAsync(1);
            if (role is null)
            {
                role = new Role() {Name = "DefaultRole", Users = new List<User>() };
                role.Users.Add(user);
            }

            if (company != null)
            {
                user.Role = role;
                user.CompanyId = companyId;
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User?> GetEntity(int id)
        {
            return await _context.Users
                .Include(user => user.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<ICollection<User>> GetEntities()
        {
            return await _context.Users
                .Include(user => user.Role)
                .ToListAsync();
        }

        public async Task<Company> GetCompanyByUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            return user.Company;
        }

        public async Task DeleteEntity(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user is null)
            {
                return;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public Task UpdateEntity(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
