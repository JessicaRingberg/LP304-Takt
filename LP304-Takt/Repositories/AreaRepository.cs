using LP304_Takt.Interfaces.Repositories;
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

        public async Task<ServiceResponse<Area>> Add(Area area, int companyId)
        {
            var found = await _context.Areas.FirstOrDefaultAsync(c => c.Name == area.Name);
            var company = await _context.Companies.FindAsync(companyId);
            if (found is not null && found.CompanyId == companyId)
            {
                return new ServiceResponse<Area>()
                {
                    Success = false,
                    Message = $"Area with name {area.Name} already exists!"
                };
            }
            
            else if (company is null)
            {
                return new ServiceResponse<Area>()
                {
                    Success = false,
                    Message = $"Area must belong to a company"
                };
            }
            else
            area.Queue = new Queue();
            area.CompanyId = companyId;
            await _context.Areas.AddAsync(area);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Area>()
            {
                Data = area,
                Success = true,
                Message = $"Area {area.Name} added"
            };
        }

        public async Task<ServiceResponse<int>> DeleteEntity(int areaId)
        {
            var area = await _context.Areas
                .FirstOrDefaultAsync(a => a.Id == areaId);
            if (area is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Area wit id {areaId} was not found"
                };
            }
            var queue = await _context.Queue
                .FirstOrDefaultAsync(q => q.Id == areaId);

            _context.Queue.Remove(queue);     
            _context.Areas.Remove(area);
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"Area with id {area.Id} deleted"
            };
        }

        public async Task<ICollection<Area>> GetEntities()
        {
            return await _context.Areas
                .Include(a => a.Stations)
                .Include(a => a.Config)
                .ToListAsync();
        }

        public async Task<Area?> GetEntity(int areaId)
        {
            return await _context.Areas
                .Include(a => a.Stations)
                .FirstOrDefaultAsync(a => a.Id == areaId);
        }

        public async Task<User?> GetAreaByUser(int userId)
        {
            var user = await _context.Users
                .Include(u => u.Area)
                .FirstOrDefaultAsync(a => a.Id == userId);
            return user;
        }

        public async Task<List<Event>> GetEventsByArea(int areaId)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return await _context.Events
                .Include(e => e.EventStatus)
                .Where(e => e.Order.AreaId == areaId).ToListAsync();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
        public async Task<List<Alarm>> GetAlarmsByArea(int areaId)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return await _context.Alarms
                .Include(a => a.AlarmType)
                .Where(a => a.Order.AreaId == areaId).ToListAsync();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        public async Task<ServiceResponse<int>> UpdateEntity(Area area, int areaId)
        {
            var areaToUpdate = await _context.Areas
                .FindAsync(areaId);
            if (areaToUpdate is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Area with id {areaId} was not found"
                };
            }

            areaToUpdate.Name = area.Name;
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"Area with id {areaId} updated"
            };
        }

    }
}
