using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Services
{
    public interface IAlarmService : IBaseService<Alarm>
    {
        Task<ServiceResponse<Alarm>> Add(Alarm alarm, int orderId, int alarmTypeId);        
    }
}
