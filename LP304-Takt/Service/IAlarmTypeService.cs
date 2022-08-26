using LP304_Takt.Models;

namespace LP304_Takt.Service
{
    public interface IAlarmTypeService
    {
        Task<IEnumerable<AlarmType>> GetAllAlarmTypes();
        Task<AlarmType> GetOneAlarmType(int id);
        Task AddAlarmType(AlarmType alarmType);
        Task RemoveAlarmType(AlarmType alarmType);
        Task<AlarmType> UpdateAlarmType(AlarmType alarmType);
    }
}
