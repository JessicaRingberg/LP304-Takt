using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;

namespace LP304_Takt.Services
{
    public class AlarmTypeService : IAlarmTypeService
    {
        private readonly IAlarmTypeRepository _alarmTypeRepository;

        public AlarmTypeService(IAlarmTypeRepository alarmTypeRepository)
        {
            _alarmTypeRepository = alarmTypeRepository;
        }
        public async Task Add(AlarmType alarmType)
        {
            await _alarmTypeRepository.Add(alarmType);
        }

        public async Task DeleteEntity(int id)
        {
            await _alarmTypeRepository.DeleteEntity(id);
        }

        public async Task<ICollection<AlarmType>> GetEntities()
        {
            return await _alarmTypeRepository.GetEntities();
        }

        public async Task<AlarmType?> GetEntity(int id)
        {
            return await _alarmTypeRepository.GetEntity(id);
        }

        public async Task UpdateEntity(AlarmType alarmType, int alarmTypeId)
        {
            await _alarmTypeRepository.UpdateEntity(alarmType, alarmTypeId);
        }
    }
}
