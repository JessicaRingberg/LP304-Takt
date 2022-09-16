using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Services
{
    public interface IAlarmTypeService : IBaseService<AlarmType>
    {
        Task<ServiceResponse<int>> Add(AlarmType alarmType);
       
    }
}
