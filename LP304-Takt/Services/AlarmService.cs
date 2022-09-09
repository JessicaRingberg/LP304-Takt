using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;

namespace LP304_Takt.Services
{
    public class AlarmService : IAlarmService
    {
        private readonly IAlarmRepository _alarmRepository;

        public AlarmService(IAlarmRepository alarmRepository)
        {
            _alarmRepository = alarmRepository;
        }
        public async Task Add(Alarm alarm, int orderId, int alarmTypeId)
        {
            await _alarmRepository.Add(alarm, orderId, alarmTypeId);
        }

        public async Task DeleteEntity(int id)
        {
            await _alarmRepository.DeleteEntity(id);
        }

        public async Task<ICollection<Alarm>> GetEntities()
        {
            return await _alarmRepository.GetEntities();
        }

        public async Task<Alarm?> GetEntity(int id)
        {
            return await _alarmRepository.GetEntity(id);
        }

        public Task UpdateAlarm(Alarm alarm, int alarmId)
        {
            throw new NotImplementedException();
        }


        public async Task UpdateEntity(Alarm alarm, int alarmId)
        {
            await _alarmRepository.UpdateEntity(alarm, alarmId);
        }

    }
}
