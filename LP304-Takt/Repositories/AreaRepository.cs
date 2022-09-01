﻿using LP304_Takt.Models;
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

             return await _context.Area.Include(area => area.Company).ToListAsync();
        }

        public async Task AddArea(Area area, int id)
        {
            var company = await _context.Company.FirstOrDefaultAsync(c => c.Id == id);
            area.Company = company;
           
            await _context.Area.AddAsync(area);
            await _context.SaveChangesAsync();

        }

        //public async Task<Area> GetOneArea(int id)
        //{
        //   var area = _context.Area.Include(area => area.Company).FirstOrDefaultAsync(area => area.Id == id);
        //   return await area.;
        //}
    }
}
