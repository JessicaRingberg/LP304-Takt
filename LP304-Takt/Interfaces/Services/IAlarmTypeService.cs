using LP304_Takt.Models;

namespace LP304_Takt.Interfaces.Services
{
    public interface IAlarmTypeService : IBaseService<AlarmType>
    {
        Task Add(AlarmType alarmType);
        Task UpdateAlarmType(AlarmType alarmType, int alarmTypeId);
    }
}
