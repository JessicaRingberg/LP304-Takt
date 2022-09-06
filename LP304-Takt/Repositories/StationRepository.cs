using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using Microsoft.EntityFrameworkCore;

namespace LP304_Takt.Repositories
{
    public class StationRepository : IStationRepository
    {
        private readonly DataContext _context;
        public StationRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task Add(Station station, int areaId)
        {
            var area = await _context.Areas.FindAsync(areaId);

            if (area != null)
            {
                station.AreaId = areaId;
                await _context.Stations.AddAsync(station);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteEntity(int id)
        {
            var station = await _context.Stations
                .FirstOrDefaultAsync(c => c.Id == id);
            if (station is null)
            {
                return;
            }
            _context.Stations.Remove(station);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Station>> GetEntities()
        {
            return await _context.Stations
                .ToListAsync(); ;
        }

        public async Task<Station?> GetEntity(int id)
        {
            return await _context.Stations
                .Include(s => s.Area)
                .Include(s => s.Orders)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public Task UpdateEntity(Station entity)
        {
            throw new NotImplementedException();
        }
    }
}
