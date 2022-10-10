using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using LP304_Takt.Shared;
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

        public async Task<ServiceResponse<int>> Add(Station station, int areaId)
        {
            var area = await _context.Areas.FindAsync(areaId);

            if (area is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Station must belong to an Area"
                };
            }
            station.AreaId = areaId;
            await _context.Stations.AddAsync(station);
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"Station {station.Name} added"
            };
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
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateEntity(Station station, int stationId)
        {
            var stationToUpdate = await _context.Stations
                .FindAsync(stationId);
            if (stationToUpdate is null)
            {
                return;
            }

            MapStation(stationToUpdate, station);

            await _context.SaveChangesAsync();
        }

        private static Station MapStation(Station newStation, Station oldStation)
        {
            newStation.Name = oldStation.Name;
            return newStation;
        }
    }
}
