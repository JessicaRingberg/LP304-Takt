using LP304_Takt.Models;
using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Shared;

namespace LP304_Takt.Services
{
    public class AreaService : IAreaService
    {
        private readonly IAreaRepository _areaRepository;

        public AreaService(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public async Task<ServiceResponse<int>> Add(Area area, int companyId)
        {
            return await _areaRepository.Add(area, companyId);
        }

        public async Task<ServiceResponse<int>> DeleteEntity(int id)
        {
            return await _areaRepository.DeleteEntity(id);
        }

        public async Task<ICollection<Area>> GetEntities()
        {
            return await _areaRepository.GetEntities();
        }

        public async Task<Area?> GetEntity(int id)
        {
            return await _areaRepository.GetEntity(id);
        }

        public async Task<List<Alarm>> GetAlarmsByArea(int areaId)
        {
            return await _areaRepository.GetAlarmsByArea(areaId);
        }

        public async Task<List<Event>> GetEventsByArea(int areaId)
        {
            return await _areaRepository.GetEventsByArea(areaId);
        }

        public async Task<ServiceResponse<int>> UpdateEntity(Area area, int areaId)
        {
            return await _areaRepository.UpdateEntity(area, areaId);
        }

        public async Task<User?> GetAreaByUser(int userId)
        {
            return await _areaRepository.GetAreaByUser(userId);
        }
    }
}
