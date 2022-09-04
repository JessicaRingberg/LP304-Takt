using LP304_Takt.Models;
using Microsoft.EntityFrameworkCore;

namespace LP304_Takt.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(LP304Context context) : base(context)
        {
        }

        public async Task<Company?> GetCompanyWithAreas(int id)
        {
            return await _context.Company.Include(c => c.Areas)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Company>> GetCompaniesWithAreas()
        {
            return await _context.Company.Include(c => c.Areas).ToListAsync();
        }


        //Does not remove related entities yet
        public async Task RemoveCompanyById(int id)
        {
            var company = await _context.Company.FirstOrDefaultAsync(c => c.Id == id);
            if (company is null)
            {
                return;
            }
            _context.Company.Remove(company);
        }
    }
}
