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

        public async Task<ServiceResponse<int>> DeleteEntity(int id)
        {
            var area = await _context.Areas
                .FirstOrDefaultAsync(a => a.Id == id);
            if (area is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Area wit id {id} was not found"
                };
            }
            var queue = await _context.Queue
                .FirstOrDefaultAsync(q => q.Id == id);

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

        public async Task<Area?> GetEntity(int id)
        {
            return await _context.Areas
                .Include(a => a.Stations)
                .FirstOrDefaultAsync(a => a.Id == id);
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
            return await _context.Events
                .Include(e => e.EventStatus)
                .Where(e => e.Order.AreaId == areaId).ToListAsync();
        }
        public async Task<List<Alarm>> GetAlarmsByArea(int areaId)
        {
            return await _context.Alarms
                .Include(a => a.AlarmType)
                .Where(a => a.Order.AreaId == areaId).ToListAsync();
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
