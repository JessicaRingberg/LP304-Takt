using LP304_Takt.DTO.ReadDto;
using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Mapper;
using LP304_Takt.Models;
using LP304_Takt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LP304_Takt.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataContext _context;

        public CompanyRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Company>> Add(Company company)
        {
            var found = await _context.Companies.FirstOrDefaultAsync(c => c.Name == company.Name);
            if(found is not null)
            {
                return new ServiceResponse<Company>()
                {
                    Success = false,
                    Message = $"Company name {company.Name} already exists!"
                };
            }
            
            await _context.Companies.AddAsync(company);

            await _context.SaveChangesAsync();
            return new ServiceResponse<Company>() 
            { 
                Data = company, 
                Success = true, 
                Message = $"Company named {company.Name} added."
            };
        }

        public async Task<ServiceResponse<int>> DeleteEntity(int id)
        {
            var company = await _context.Companies
                .Include(c => c.Users)
                
                .FirstOrDefaultAsync(c => c.Id == id);
            if (company is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Company with id {id} was not found"
                };
            }
            _context.Users.RemoveRange(company.Users);
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"Company {company.Name} deleted"
            };
        }

        public async Task<ICollection<Company>> GetEntities()
        {
            return await _context.Companies
                .Include(c => c.Users)
                .Include(c => c.Areas)
                .ThenInclude(a => a.Stations)
                .ToListAsync();
        }

        public async Task<Company?> GetEntity(int id)
        {
            return await _context.Companies
                .Include(c => c.Users)
                .Include(c => c.Areas)
                .ThenInclude(a => a.Stations)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ICollection<User>> GetUserByCompany(int companyId)
        {
            return await _context.Users.Where(u => u.CompanyId == companyId).ToListAsync();
        }

        public async Task<ServiceResponse<int>> UpdateEntity(Company company, int companyId)
        {
            var companyToUpdate = await _context.Companies
                .FindAsync(companyId);
            if (companyToUpdate is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Company with {companyId} was not found"
                };
            }
            companyToUpdate.Name = company.Name;
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"Company {company.Name} updated"
            };
        }

    }
}
