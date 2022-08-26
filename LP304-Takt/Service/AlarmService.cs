using LP304_Takt.Models;
using LP304_Takt.UnitOfWork;

namespace LP304_Takt.Service
{
    public class AlarmService : IAlarmService
    {
        private readonly IUnitOfWork _alarmUnitOfWork;

        public AlarmService(IUnitOfWork alarmUnitOfWork)
        {
            _alarmUnitOfWork = alarmUnitOfWork;
        }
        public async Task AddAlarm(Alarm alarm)
        {
            await _alarmUnitOfWork.Alarms.Add(alarm);
        }

        public async Task<IEnumerable<Alarm>> GetAllAlarms()
        {
            return await _alarmUnitOfWork.Alarms.GetAll();
        }

        public async Task<Alarm> GetOneAlarm(int id)
        {
            return await _alarmUnitOfWork.Alarms.GetById(id);
        }

        public async Task RemoveAlarm(Alarm alarm)
        {
            await _alarmUnitOfWork.Alarms.Remove(alarm);
        }

        public async Task<Alarm> UpdateAlarm(Alarm alarm)
        {
            return await _alarmUnitOfWork.Alarms.Update(alarm);
        }
    }
}
