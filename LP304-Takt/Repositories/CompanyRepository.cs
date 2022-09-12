using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using Microsoft.EntityFrameworkCore;

namespace LP304_Takt.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataContext _context;

        public CompanyRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(Company company)
        {
            await _context.Companies.AddAsync(company);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntity(int id)
        {
            var company = await _context.Companies
                .FirstOrDefaultAsync(c => c.Id == id);
            if (company is null)
            {
                return;
            }
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Company>> GetEntities()
        {
            return await _context.Companies
                .Include(c => c.Users)
                .ThenInclude(u => u.Role)
                .Include(c => c.Areas)
                .ThenInclude(a => a.Stations)
                .ToListAsync();
        }

        public async Task<Company?> GetEntity(int id)
        {
            return await _context.Companies
                .Include(c => c.Users)
                .ThenInclude(u => u.Role)
                .Include(c => c.Areas)
                .ThenInclude(a => a.Stations)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ICollection<User>> GetUserByCompany(int companyId)
        {
            return await _context.Users.Where(u => u.CompanyId == companyId).ToListAsync();
        }


        public async Task UpdateEntity(Company company, int companyId)
        {
            var companyToUpdate = await _context.Companies
                .FindAsync(companyId);
            if (companyToUpdate is null)
            {
                return;
            }
            companyToUpdate.Name = company.Name;

            MapCompany(companyToUpdate, company);

            await _context.SaveChangesAsync();
        }


        private static Company MapCompany(Company newComp, Company oldComp)
        {
            newComp.Name = oldComp.Name;
            return newComp;
        }
    }
}
