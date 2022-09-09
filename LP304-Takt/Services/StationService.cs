using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;

namespace LP304_Takt.Services
{
    public class StationService : IStationService
    {
        readonly IStationRepository _stationRepository;

        public StationService(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task Add(Station station, int areaId)
        {
            await _stationRepository.Add(station, areaId);
        }

        public async Task DeleteEntity(int id)
        {
            await _stationRepository.DeleteEntity(id);
        }

        public async Task<ICollection<Station>> GetEntities()
        {
            return await _stationRepository.GetEntities();
        }

        public async Task<Station?> GetEntity(int id)
        {
            return await _stationRepository.GetEntity(id);
        }

        public async Task UpdateEntity(Station station, int stationId)
        {
            await _stationRepository.UpdateEntity(station, stationId);
        }
    }
}
