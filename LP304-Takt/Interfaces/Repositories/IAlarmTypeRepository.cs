using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IAlarmTypeRepository : IBaseRepository<AlarmType>
    {
        Task<ServiceResponse<AlarmType>> Add(AlarmType alarmType);        
    }
}
