using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using Microsoft.EntityFrameworkCore;

namespace LP304_Takt.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext _context;

        public RoleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteEntity(int id)
        {
            var role = await _context.Roles
                .FirstOrDefaultAsync(r => r.Id == id);
            if (role is null)
            {
                return;
            }
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Role>> GetEntities()
        {
            return await _context.Roles
                .Include(c => c.Users)
                .ToListAsync();
        }

        public async Task<Role?> GetEntity(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

    }
}
