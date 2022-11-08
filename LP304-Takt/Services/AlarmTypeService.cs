using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Services
{
    public class AlarmTypeService : IAlarmTypeService
    {
        private readonly IAlarmTypeRepository _alarmTypeRepository;

        public AlarmTypeService(IAlarmTypeRepository alarmTypeRepository)
        {
            _alarmTypeRepository = alarmTypeRepository;
        }
        public async Task<ServiceResponse<AlarmType>> Add(AlarmType alarmType)
        {
            return await _alarmTypeRepository.Add(alarmType);
        }

        public async Task<ServiceResponse<int>> DeleteEntity(int alarmTypeId)
        {
            return await _alarmTypeRepository.DeleteEntity(alarmTypeId);
        }

        public async Task<ICollection<AlarmType>> GetEntities()
        {
            return await _alarmTypeRepository.GetEntities();
        }

        public async Task<AlarmType?> GetEntity(int alarmTypeId)
        {
            return await _alarmTypeRepository.GetEntity(alarmTypeId);
        }

        public async Task<ServiceResponse<int>> UpdateEntity(AlarmType alarmType, int alarmTypeId)
        {
           return await _alarmTypeRepository.UpdateEntity(alarmType, alarmTypeId);
        }
    }
}
