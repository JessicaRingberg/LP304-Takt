using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Services
{
    public class AlarmService : IAlarmService
    {
        private readonly IAlarmRepository _alarmRepository;

        public AlarmService(IAlarmRepository alarmRepository)
        {
            _alarmRepository = alarmRepository;
        }
        public async Task<ServiceResponse<Alarm>> Add(Alarm alarm, int orderId, int alarmTypeId)
        {
           return await _alarmRepository.Add(alarm, orderId, alarmTypeId);
        }

        public async Task<ServiceResponse<int>> DeleteEntity(int alarmId)
        {
            return await _alarmRepository.DeleteEntity(alarmId);
        }

        public async Task<ICollection<Alarm>> GetEntities()
        {
            return await _alarmRepository.GetEntities();
        }

        public async Task<Alarm?> GetEntity(int alarmId)
        {
            return await _alarmRepository.GetEntity(alarmId);
        }

        public async Task<ServiceResponse<int>> UpdateEntity(Alarm alarm, int alarmId)
        {
            return await _alarmRepository.UpdateEntity(alarm, alarmId);
        }

    }
}
