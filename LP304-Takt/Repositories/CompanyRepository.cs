﻿using LP304_Takt.Models;
using Microsoft.EntityFrameworkCore;

namespace LP304_Takt.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(LP304Context context) : base(context)
        {
        }

        //public async Task<IEnumerable<Company>> GetAllCompanies()
        //{
        //  return await _context.Company.Include(c => c.Areas).ToListAsync();
        //}
    }
}
