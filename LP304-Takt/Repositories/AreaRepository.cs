﻿using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using LP304_Takt.Shared;
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

        public async Task<ServiceResponse<int>> Add(Area area, int companyId)
        {
            var company = await _context.Companies.FindAsync(companyId);

            if (company is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Area must belong to a company"
                };
            }
            area.Queue = new Queue();
            area.CompanyId = companyId;
            await _context.Areas.AddAsync(area);
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"Area {area.Name} added"
            };
        }

        public async Task DeleteEntity(int id)
        {
            var area = await _context.Areas
                .FirstOrDefaultAsync(a => a.Id == id);
            if (area is null)
            {
                return;
            }
            _context.Areas.Remove(area);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Area>> GetEntities()
        {
            return await _context.Areas
                .Include(a => a.Stations)
                .Include(a => a.Config)
                .ToListAsync();
        }

        public async Task<Area?> GetEntity(int id)
        {
            return await _context.Areas
                .Include(a => a.Stations)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task UpdateEntity(Area area, int areaId)
        {
            var areaToUpdate = await _context.Areas
                .FindAsync(areaId);
            if (areaToUpdate is null)
            {
                return;
            }

            MapArea(areaToUpdate, area);

            await _context.SaveChangesAsync();
        }

        private static Area MapArea(Area newArea, Area oldArea)
        {
            newArea.Name = oldArea.Name;
            return newArea;
        }


    }
}
