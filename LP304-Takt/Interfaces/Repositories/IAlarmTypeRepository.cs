using LP304_Takt.Models;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IAlarmTypeRepository : IBaseRepository<AlarmType>
    {
        Task Add(AlarmType alarmType);
        //Task UpdateAlarmType(AlarmType alarmType, int alarmTypeId);
    }
}
