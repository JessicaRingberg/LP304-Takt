using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Services
{
    public class StationService : IStationService
    {
        readonly IStationRepository _stationRepository;

        public StationService(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task<ServiceResponse<Station>> Add(Station station, int areaId)
        {
            return await _stationRepository.Add(station, areaId);
        }

        public async Task<ServiceResponse<int>> DeleteEntity(int stationId)
        {
            return await _stationRepository.DeleteEntity(stationId);
        }

        public async Task<ICollection<Station>> GetEntities()
        {
            return await _stationRepository.GetEntities();
        }

        public async Task<Station?> GetEntity(int stationId)
        {
            return await _stationRepository.GetEntity(stationId);
        }

        public async Task<ServiceResponse<int>> UpdateEntity(Station station, int stationId)
        {
            return await _stationRepository.UpdateEntity(station, stationId);
        }
    }
}
