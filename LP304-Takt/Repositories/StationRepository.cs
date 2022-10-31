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
            var found = await _context.Stations
                .FirstOrDefaultAsync(s => s.Name.Equals(station.Name) && s.Id.Equals(areaId));
            if (found is not null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"This area already has a station with name {station.Name}!"
                };
            }

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

        public async Task<ServiceResponse<int>> DeleteEntity(int id)
        {
            var station = await _context.Stations
                .FirstOrDefaultAsync(c => c.Id == id);
            if (station is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Station with id {id} was not found"
                };
            }
            _context.Stations.Remove(station);
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"Station with id {id} deleted"
            };
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

        public async Task<ServiceResponse<int>> UpdateEntity(Station station, int stationId)
        {
            var stationToUpdate = await _context.Stations
                .FindAsync(stationId);
            if (stationToUpdate is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Station with id {stationId} was not found"
                };
            }

            stationToUpdate.Name = station.Name;
            stationToUpdate.Active = station.Active;
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"Station with id {stationId} updated"
            };
        }
    }
}
