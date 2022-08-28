using LP304_Takt.Models;

namespace LP304_Takt.Service
{
    public interface IAlarmService
    {
        Task<IEnumerable<Alarm>> GetAllAlarms();
        Task<Alarm> GetOneAlarm(int id);
        Task AddAlarm(Alarm alarm);
        Task RemoveAlarm(Alarm alarm);
        Task<Alarm> UpdateAlarm(Alarm alarm);
        Task DeleteById(int id);
    }
}
