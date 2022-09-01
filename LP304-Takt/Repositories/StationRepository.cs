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
            var area = await _context.Area.FirstOrDefaultAsync(c => c.Id == id);
            station.Area = area;

            await _context.Station.AddAsync(station);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Station>> GetAllStations()
        {
            return await _context.Station.Include(a => a.Area).ToListAsync();
        }
    }
}
