using LP304_Takt.Models;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IAlarmRepository : IBaseRepository<Alarm>
    {
        Task Add(Alarm alarm, int orderId, int alarmTypeId);
        //Task UpdateAlarm(Alarm alarm, int alarmId);
    }
}
