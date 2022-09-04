using LP304_Takt.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace LP304_Takt.Repositories
{
    public class AreaRepository : GenericRepository<Area>, IAreaRepository
    {
        public AreaRepository(LP304Context context) : base(context)
        {

        }

        public async Task<IEnumerable<Area>> GetAllAreas()
        {

             return await _context.Area.ToListAsync();
        }

        public async Task<Area?>  GetOneArea(int id)
        {
            return await _context.Area
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddArea(Area area, int id)
        {
            await _context.Area.AddAsync(area);
            var company = await _context.Company.FindAsync(id);
            if (company is null)
            {
                return;
            }
            if (company.Areas.Contains(area))
            {
                return;
            }
            company.Areas.Add(area);
            await _context.SaveChangesAsync();

        }

        public async Task RemoveArea(Area area)
        {
            _context.Area.Remove(area);
            await _context.SaveChangesAsync();
        }
    }
}
