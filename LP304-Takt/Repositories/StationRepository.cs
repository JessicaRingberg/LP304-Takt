using LP304_Takt.Models;
using Microsoft.EntityFrameworkCore;

namespace LP304_Takt.Repositories
{
    public class StationRepository : GenericRepository<Station>, IStationRepository
    {
        public StationRepository(LP304Context context) : base(context)
        {

        }

        public async Task AddStation(Station station, int id)
        {
            var area = await _context.Area.FirstOrDefaultAsync(a => a.Id == id);
            station.Area = area;
            if (area is null)
                return;

            await _context.Station.AddAsync(station);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Station>> GetAllStations()
        {
            return await _context.Station.Include(s => s.Area)
                .ThenInclude(s => s.Company).ToListAsync();
        }
    }
}
