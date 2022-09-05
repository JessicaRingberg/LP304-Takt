using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace LP304_Takt.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly DataContext _context;

        public AreaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(Area area, int companyId)
        {
            var company = await _context.Companies.FindAsync(companyId);

            if (company != null)
            {
                area.CompanyId = companyId;
                await _context.Areas.AddAsync(area);
                await _context.SaveChangesAsync();
            }
        }

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Area>> GetEntities()
        {
            return await _context.Areas.ToListAsync();
        }

        public async Task<Area?> GetEntity(int id)
        {
            return await _context.Areas.FindAsync();
        }
    }
}
