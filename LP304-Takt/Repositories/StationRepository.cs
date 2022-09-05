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

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Station>> GetEntities()
        {
            throw new NotImplementedException();
        }

        public Task<Station> GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntity(Station entity)
        {
            throw new NotImplementedException();
        }
    }
}
